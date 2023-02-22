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
using InstantLista_DataAccess.Repositories;

namespace InsantLista_Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _userRepository;
        /*private readonly IUserContactsRepository _userContactsRepository;
        private readonly IFeedItemRepository _feedItemRepository;
        private readonly IApprovalItemRepository _approvalItemRepository;*/

        public UserService(IUsersRepository userRepository/*, IUserContactsRepository userContactsRepository, IFeedItemRepository feedItemRepository, IApprovalItemRepository approvalItemRepository*/)
        {
            _userRepository = userRepository;
            /*_userContactsRepository = userContactsRepository;
            _feedItemRepository = feedItemRepository;
            _approvalItemRepository = approvalItemRepository;*/
        }

        public async Task<UserDto> GetUser(int userId)
        {
            var user = (await _userRepository.readAll()).FirstOrDefault(u => u.Id == userId);

            var userDto =  new UserDto()
            {
                Id = user.Id,
                Name = $"{user.FirstName} {user.LastName}",
                UserName = user.UserName,
                Email = user.Email,
                Icon = user.Icon
            
            };

            return userDto;
        }
        /*public async Task<IEnumerable<UserContact>> GetContacts(int userNumber)
        {
            var userContacts = await _userContactsRepository.GetItemByUserNumber(new UserContactQuerySpecifications(userNumber));

            return new ValidatedResult<IEnumerable<UserContact>>
            {
                Result = userContacts.Contacts.Select(uc => new UserContact
                {
                    UserNumber = uc.UserNumber,
                    UserName = uc.UserName,
                    Icon = uc.Icon
                })
            };
        }

        public async Task<ValidatedResult<IEnumerable<FeedItem>>> GetUserFeed(int userNumber)
        {
            var userContacts = await _userContactsRepository.GetItemByUserNumber(new UserContactQuerySpecifications(userNumber));

            var feedItems = await _feedItemRepository.GetFeedItemsByUserNumber(new FeedItemQuerySpecifications(userContacts.Contacts.Select(u => u.UserNumber)));

            return new ValidatedResult<IEnumerable<FeedItem>>
            {
                Result = feedItems
            };
        }

        public async Task<ValidatedResult<IEnumerable<ApprovalItem>>> GetUserApprovals(int userNumber)
        {
            var approvalItems = await _approvalItemRepository.GetApprovalItemsByUserNumber(new PendingApprovalItemsQuerySpecifications(userNumber));

            return new ValidatedResult<IEnumerable<ApprovalItem>>
            {
                Result = approvalItems
            };
        }

        public async Task<ValidatedResult<IEnumerable<ApprovalItem>>> GetLatestApprovals(int userNumber)
        {
            var approvalItems = await _approvalItemRepository.GetApprovalItemsByUserNumber(new ApprovedItemsQuerySpecifications(userNumber));

            return new ValidatedResult<IEnumerable<ApprovalItem>>
            {
                Result = approvalItems.Take(20)
            };
        */

    }
}
