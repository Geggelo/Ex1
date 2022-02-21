using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EX.Entities;

namespace EX.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly Utilities _utilities;

        public PersonController(ILogger<PersonController> logger, Utilities utilities)
        {
            _logger = logger;
            _utilities = utilities;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            _logger.LogInformation("Requested all people information");
            try
            {
                return Ok(_utilities.Deserializer().SelectMany(x => x.people).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetPerson(string name)
        {
            try
            {
                return Ok(_utilities.Deserializer().SelectMany(x => x.people).FirstOrDefault(p => p.firstName.ToUpper() == name.ToUpper()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPerson(string firstName, string lastName, int age, string address, string cityName)
        {
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.FirstOrDefault(x => x.name == cityName);
                if (target == null)
                    return BadRequest("Città non esistente");
                var check = cities.SelectMany(x => x.people).FirstOrDefault(p => p.firstName.ToUpper() == firstName.ToUpper());
                if (check != null)
                    return BadRequest("Perosna già esistente");

                Person p = new Person(firstName, lastName, age, address);
                target.people.Add(p);
                _utilities.Serializer(cities);
                return Ok(target);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeletePerson(string name)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePerson(string name)
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult PatchPerson(string name)
        {
            return Ok();
        }
    }
}
