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

        private PersonController(ILogger<PersonController> logger, Utilities utilities)
        {
            _logger = logger;
            _utilities = utilities;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
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
                return Ok(_utilities.Deserializer().SelectMany(x => x.people).FirstOrDefault(p => p.FirstName.ToUpper() == name.ToUpper()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPerson(string name)
        {
            return Ok();
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
