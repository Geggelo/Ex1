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

        [HttpPost]
        public IActionResult AddPerson(string firstName, string lastName, int age, string address, string cityName)
        {
            _logger.LogInformation("Requested creation of a new person entry");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.FirstOrDefault(x => x.name == cityName);
                if (target == null)
                    return BadRequest($"{cityName} deos not exist");
                var check = target.people.FirstOrDefault(p => p.firstName.ToUpper() == firstName.ToUpper());
                if (check != null)
                    return BadRequest($"{firstName} already exists in {cityName}");
                target.people.Add(new Person(firstName, lastName, age, address));
                _logger.LogInformation($"{firstName} {lastName} successfully created");
                _utilities.Serializer(cities);
                return Ok(target);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
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
        [Route("{firstName}")]
        public IActionResult GetPerson(string firstName)
        {
            _logger.LogInformation($"Requested {firstName} information");
            try
            {
                return Ok(_utilities.Deserializer().SelectMany(x => x.people).FirstOrDefault(p => p.firstName.ToUpper() == firstName.ToUpper()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeletePerson(string firstName)
        {
            _logger.LogInformation($"Requested removal of {firstName}");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.SelectMany(x => x.people).FirstOrDefault(p => p.firstName.ToUpper() == firstName.ToUpper());
                if (target == null)
                    return BadRequest($"{firstName} does not exist");
                cities.ForEach(c => c.people.Remove(target));
                _logger.LogInformation($"{firstName} successfully removed");
                return Ok(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdatePerson(string firstName, string lastName, int age, string address)
        {
            _logger.LogInformation($"Requested information update of {firstName}");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.SelectMany(x => x.people).FirstOrDefault(p => p.firstName.ToUpper() == firstName.ToUpper());
                if (target == null)
                    return BadRequest($"{firstName} does not exist");
                target.Updater(firstName, lastName, age, address);
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
        public IActionResult PatchPerson(string firstName, string address)
        {
            _logger.LogInformation($"Requested address update of {firstName}");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.SelectMany(x => x.people).FirstOrDefault(p => p.firstName.ToUpper() == firstName.ToUpper());
                if (target == null)
                    return BadRequest($"{firstName} does not exist");
                target.address = address;
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
