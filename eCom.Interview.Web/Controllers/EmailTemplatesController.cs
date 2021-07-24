using eCom.Interview.Application.Repository;
using eCom.Interview.Domain.Models;
using eCom.Interview.Web.Models.Response;

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace eCom.Interview.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTemplatesController : ControllerBase
    {
        private readonly IRepository<EmailTemplate> _dataRepository;
        public EmailTemplatesController(IRepository<EmailTemplate> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string searchKeyword, int skip = 0, int take = 0, string orderBy = "emailLabel", string sortOrder = "ascending")
        {
            //@TODO : all this logic should be transferred to another service
            int count = 0;
            var emailTemplates = await _dataRepository
                .Where(e => string.IsNullOrEmpty(searchKeyword) ?
                    e.Active == true :
                    (e.EmailLabel.ToLower().Contains(searchKeyword.ToLower()) || e.FromAddress.ToLower().Contains(searchKeyword.ToLower())));

            string orderByQuery = orderBy.ToUpper() + $" { (sortOrder == "ascending" ? "ASC" : "DESC") }";
            emailTemplates = emailTemplates.OrderBy(orderByQuery);

            count = emailTemplates.Count();

            if (skip > 0) {
                emailTemplates = emailTemplates.Skip(skip);
            }
            if (take > 0) {
                emailTemplates = emailTemplates.Take(take);
            }
            //transfer

            var response = new DataResponse<EmailTemplate>()
            {
                Result = emailTemplates,
                Count = count
            };

            return Ok(response);
        }
    }
}
