using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject;

namespace backend_person_app.Controllers
{
    [Route("api/persons")]
    [ApiController]
    [ApiExplorerSettings]
    public class PersonController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public PersonController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _serviceManager.PersonService.GetAllPersonAsync();
            return Ok(persons);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            var person = await _serviceManager.PersonService.GetPersonByIdAsync(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonCreateDTO person)
        {
            var createdPerson = await _serviceManager.PersonService.AddPersonAsync(person);
            return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.Id }, createdPerson);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            await _serviceManager.PersonService.DeletePersonAsync(id);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePerson(Guid id, [FromBody] PersonUpdateDTO person)
        {
            await _serviceManager.PersonService.UpdatePersonAsync(id, person);

            return NoContent();
        }
    }
}
