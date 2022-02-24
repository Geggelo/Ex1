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

        [HttpPost]
        public IActionResult AddCity(string name, string province, string country, int postalCode)
        {
            _logger.LogInformation("Requested creation of a new city entry");
            try
            {
                List<City> cities = _utilities.Deserializer();
                if (cities.Any(c => c.name.ToUpper() == name.ToUpper()))
                    return BadRequest("This city already exists");
                City newest = new City(name, province, country, postalCode);
                newest.id = Guid.NewGuid();
                cities.Add(newest);
                _logger.LogInformation($"{name} entry successfully created");
                _utilities.Serializer(cities);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            _logger.LogInformation("Requested all cities information");
            return Ok(_utilities.Deserializer());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingleData(Guid id)
        {
            _logger.LogInformation($"Requested {id} information");
            List<City> cities = _utilities.Deserializer();
            var target = cities.FirstOrDefault(c => c.id == id);
            if (target == null)
                return NotFound($"Could not find city with {id}");
            return Ok(target);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCity(Guid id)
        {
            _logger.LogInformation($"Requested removal of city with id: {id}");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.FirstOrDefault(c => c.id == id);
                if (target == null)
                    return BadRequest("This city does not exists");
                cities.Remove(target);
                _logger.LogInformation($"{id} successfully removed");
                _utilities.Serializer(cities);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateCity(Guid id, string name, string province, string country, int postalCode)
        {
            _logger.LogInformation($"Requested information update of city with id: {id}");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.FirstOrDefault(c => c.id == id);
                if (target == null)
                    return BadRequest("This city does not exists");
                target.Updater(name, province, country, postalCode);
                _logger.LogInformation($"{name} information updated");
                _utilities.Serializer(cities);
                return Ok(target);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult PatchCity(Guid id, string newName)
        {
            _logger.LogInformation($"Requested name update of city with id: {id}");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.FirstOrDefault(c => c.id == id);
                if (target == null)
                    return BadRequest("This city does not exists");
                target.name = newName;
                _utilities.Serializer(cities);
                return Ok(target);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
