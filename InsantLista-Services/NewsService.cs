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
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        /*private readonly IUserContactsRepository _userContactsRepository;
        private readonly IFeedItemRepository _feedItemRepository;
        private readonly IApprovalItemRepository _approvalItemRepository;*/

        public NewsService(INewsRepository newsRepository/*, IUserContactsRepository userContactsRepository, IFeedItemRepository feedItemRepository, IApprovalItemRepository approvalItemRepository*/)
        {
            _newsRepository = newsRepository;
            /*_userContactsRepository = userContactsRepository;
            _feedItemRepository = feedItemRepository;
            _approvalItemRepository = approvalItemRepository;*/
        }

        public async Task<IEnumerable<NewsDto>> GetNews()
        {
            var news = await _newsRepository.readAll();
            var result = new List<NewsDto>();

            foreach (var element in news)
            {
                result.Add(new NewsDto
                {
                    Id=element.Id,
                    Title=element.Title,
                    Description=element.Description,
                    Image=element.Image,
                    Url=element.Url
                });
            }

            return result;
        }
    }
}
