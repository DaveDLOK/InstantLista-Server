using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using InsantLista_Services.Interfaces;
using InstantLista_ClassLibrary;
using InstantLista_ClassLibrary.Helpers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using InstantLista_DataAccess.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace InsantLista_Services.Services
{ 
    public class AuthenticationService:IAuthenticationService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly AppSettings _appSettings;

        public AuthenticationService(IUsersRepository usersRepository, IMembershipRepository membershipRepository, IOptions<AppSettings> appSettings)
        {
            _usersRepository = usersRepository;
            _membershipRepository = membershipRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<TokenJWTDto> Authenticate(string userName, string passWord)
        {
            using var hasher = SHA256.Create();

            /*var salt = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var newMem = new Membership { Id = 1, LastLogin = DateTimeOffset.UtcNow, Salt = salt, Password = hasher.ComputeHash(passWord.Select(p => (byte)p).Concat(salt).ToArray()) };

            await _membershipRepository.Create(newMem);*/
            Expression<Func<User, bool>> userModifier = u => u.Email == userName || u.UserName == userName;
            var user = (await _usersRepository.readAll(userModifier)).FirstOrDefault();

            if (user == null) 
            {
                return null;
            }

            Expression<Func<Membership, bool>> membershipModifier = mm => mm.Id == user.Id;
            var membership = (await _membershipRepository.readAll(membershipModifier)).FirstOrDefault();

            if (membership == null)
            {
                return null;
            }

            
            var hashedPassword = hasher.ComputeHash(passWord.Select(p => (byte)p).Concat(membership.Salt).ToArray());

            if (!hashedPassword.SequenceEqual(membership.Password))
            {
                return null;
            }

            var jwt = GenerateAccessToken(user.Id);

            await UpdateToken(user, jwt.IdToken);

            return jwt;

        }

        private TokenJWTDto GenerateAccessToken(int userNumber)
        {
            var claims = new List<Claim> { new Claim("UserNumber", userNumber.ToString()) };
            var accessTokenSeconds = 2 * 60;


            claims.Add(new Claim("ExpiredPassword", false.ToString()));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(accessTokenSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var jwt = new TokenJWTDto
            {
                IdToken = tokenString,
                ExpiresIn = accessTokenSeconds.ToString(),
                UserNumber = userNumber.ToString()
            };

            return jwt;
        }

        public async Task<TokenJWTDto> Refresh(string bearertoken, string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.ReadJwtToken(bearertoken);
            var userNumber = Int32.Parse(token.Claims.First(c => c.Type == "UserNumber").Value);

            //TODO create a Refresh document type in collection to store user used tokens and validate against token provided

            //check if token exist
            Expression<Func<User, bool>> userModifier = um => um.Id == userNumber;
            var user = (await _usersRepository.readAll(userModifier)).FirstOrDefault();

            if (user.UserToken != refreshToken)
            {
                //if not exist return null and handle the error.
                return null;
            }

            //Generate a new token
            var jwt = GenerateAccessToken(userNumber);

            //save new token to validate in next refresh
            await UpdateToken(user, jwt.IdToken);

            //return new refreshed token
            return jwt;
        }

        private async Task UpdateToken(User user, string saveToken)
        {
            user.UserToken = saveToken;

            await _usersRepository.Update(user);
        }
    }
}
