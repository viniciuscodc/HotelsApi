using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using HotelsApi.IRepository;
using HotelsApi.Data;

namespace HotelsApi.Controllers
{
    [ApiVersion("2.0", Deprecated = true)]
    [ApiController]
    [Route("api/country")]
    public class CountryV2Controller : ControllerBase
    {
        private DatabaseContext _context;

        public CountryV2Controller(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(_context.Countries); 
        }
    }
}