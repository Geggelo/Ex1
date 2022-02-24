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
        public IActionResult AddPerson(string firstName, string lastName, int age, string address, Guid cityID)
        {
            _logger.LogInformation("Requested creation of a new person entry");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.FirstOrDefault(x => x.id == cityID);
                if (target == null)
                    return BadRequest($"{cityID} deos not exist");
                Person newest = new Person(firstName, lastName, age, address, cityID);
                newest.id = Guid.NewGuid();
                target.people.Add(newest);
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
        [Route("{id}")]
        public IActionResult GetPerson(Guid id)
        {
            _logger.LogInformation($"Requested {id} information");
            try
            {
                return Ok(_utilities.Deserializer().SelectMany(x => x.people).FirstOrDefault(p => p.id == id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            _logger.LogInformation($"Requested removal of person with id: {id}");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.SelectMany(x => x.people).FirstOrDefault(p => p.id == id);
                if (target == null)
                    return BadRequest($"{id} does not exist");
                var env = cities.FirstOrDefault(c => c.id == target.cityId);
                cities.ForEach(c => c.people.Remove(target));
                _logger.LogInformation($"{target.firstName} {target.lastName} successfully removed");
                _utilities.Serializer(cities);
                return Ok(env);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdatePerson(Guid id, string firstName, string lastName, int age, string address)
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
        public IActionResult PatchPerson(Guid id, string address)
        {
            _logger.LogInformation($"Requested address update of person with id: {id}");
            try
            {
                List<City> cities = _utilities.Deserializer();
                var target = cities.SelectMany(x => x.people).FirstOrDefault(p => p.id == id);
                if (target == null)
                    return BadRequest($"{id} does not exist");
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
