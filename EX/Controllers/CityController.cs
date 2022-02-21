using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EX.Entities;

namespace EX.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly Utilities _utilities;

        public CityController(ILogger<CityController> logger, Utilities utilities)
        {
            _logger = logger;
            _utilities = utilities;
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            _logger.LogInformation("Requested all cities information");
            return Ok(_utilities.Deserializer());
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetSingleData(string name)
        {
            List<City> cities = _utilities.Deserializer();
            var target = cities.FirstOrDefault(c => c.name.ToUpper() == name.ToUpper());
            if (target == null)
                return NotFound($"Could not find {name}");
            return Ok(target);
        }

        //[HttpPost]
        //public IActionResult AddCity(string name, string province, string country, int postalCode)
        //{
        //    try
        //    {

        //    }
        //}
    }
}
