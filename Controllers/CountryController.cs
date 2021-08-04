using System;
using System.Collections.Generic;
using HotelsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HotelsApi.IRepository;
using System.Threading.Tasks;
using AutoMapper;

namespace HotelsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, 
        IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(GetCountries)}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(
                    q => q.Id == id, new List<string> {"Hotels"});

                var result = _mapper.Map<CountryDTO>(country);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(GetCountries)}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}