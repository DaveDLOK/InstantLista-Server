﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using InsantLista_Services.Interfaces;
using InstantLista_ClassLibrary.DataTransferObjects;
using InstantLista_ClassLibrary.Helpers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace InsantLista_Services.Services
{ 
    public class AuthenticationService:IAuthenticationService
    {
        //private readonly IUserRepository _userRepository;
        //private readonly IMembershipRepository _membershipRepository;
        private readonly AppSettings _appSettings;

        public AuthenticationService(/*IUserRepository userRepository, IMembershipRepository membershipRepository,*/ IOptions<AppSettings> appSettings)
        {
            //_userRepository = userRepository;
            //_membershipRepository = membershipRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<TokenJWTDto> Authenticate(string userName, string passWord)
        {
            //var user = (await _userRepository.GetItemsAsync(new UserQuerySpecifications(userName))).FirstOrDefault();

            var user = "David";
            if (user == null)
            {
                return null;
            }

            //var membership = await _membershipRepository.GetItemByUserNumber(new MembershipSpecifications(user.UserNumber));

            /*using var hasher = SHA256.Create();
            var hashedPassword = hasher.ComputeHash(passWord.Select(p => (byte)p).Concat(membership.Salt).ToArray());

            if (!hashedPassword.SequenceEqual(membership.Password))
            {
                return new ValidatedResult<TokenJWT> { ErrorCode = "BadCredentials" };
            }*/

            var jwt = GenerateAccessToken(12345/*user.UserNumber*/);

            //await UpdateToken(user, jwt.IdToken);

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

        /*public async Task<ValidatedResult<TokenJWT>> Refresh(string bearertoken, string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.ReadJwtToken(bearertoken);
            var userNumber = Int32.Parse(token.Claims.First(c => c.Type == "UserNumber").Value);

            //TODO create a Refresh document type in collection to store user used tokens and validate against token provided

            //check if token exist
            var user = await _userRepository.GetItemByUserNumber(new UserQuerySpecifications(userNumber));

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
            return new ValidatedResult<TokenJWT> { Result = jwt };
        }

        private async Task UpdateToken(User user, string saveToken)
        {
            user.UserToken = saveToken;

            await _userRepository.UpdateItemAsync(user.Id, user);
        }*/
    }
}
