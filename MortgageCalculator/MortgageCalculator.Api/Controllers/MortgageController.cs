using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MortgageCalculator.Api.Services;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Api.Controllers
{
    public class MortgageController : ApiController
    {
        // GET: api/Mortgage
        [HttpGet]
        [Route("api/Mortgage")]
        public IEnumerable<Mortgage> Get()
        {
           var mortgageService = new MortgageService();
           return mortgageService.GetAllMortgages();
        }

        // GET: api/Mortgage/5
        [HttpGet]
        [Route("api/Mortgage/{id}")]
        public Mortgage Get(int id)
        {
            var mortgageService = new MortgageService();
            return mortgageService.GetAllMortgages().FirstOrDefault(x => x.MortgageId == id);
        }
    }
}
