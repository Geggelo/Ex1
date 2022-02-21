﻿using Microsoft.AspNetCore.Http;
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
            _logger.LogInformation($"Requested {name} information");
            List<City> cities = _utilities.Deserializer();
            var target = cities.FirstOrDefault(c => c.name.ToUpper() == name.ToUpper());
            if (target == null)
                return NotFound($"Could not find {name}");
            return Ok(target);
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
                cities.Add(new City(name, province, country, postalCode));
                _logger.LogInformation($"{name} entry created");
                _utilities.Serializer(cities);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCity(string name)
        {
            List<City> cities = _utilities.Deserializer();
            var target = cities.FirstOrDefault(c => c.name.ToUpper() == name.ToUpper());
            if (target == null)
                return BadRequest("This city already exists");
            cities.Remove(target);
            _utilities.Serializer(cities);
            return Ok(cities);
        }

        [HttpPut]
        public IActionResult UpdateCity(string name)
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult PatchCity(string name)
        {
            return Ok();
        }
    }
}
