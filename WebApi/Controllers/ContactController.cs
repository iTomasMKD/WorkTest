using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository repository;

        public ContactController(IContactRepository _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            try
            {
                var Contact = await repository.GetAllContactsAsync();

                return Ok(Contact);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ContactById")]
        public async Task<IActionResult> GetContactById(Guid id)
        {
            try
            {
                var Contact = await repository.GetContactByIdAsync(id);
                if (Contact == null)
                {

                    return NotFound();
                }
                else
                {

                    return Ok(Contact);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetContactWithDetails(Guid id)
        {
            try
            {
                var Contact = await repository.GetContactWithDetailsAsync(id);
                if (Contact == null)
                {

                    return NotFound();
                }
                else
                {

                    return Ok(ContactResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact Contact)
        {
            try
            {
                if (Contact == null)
                {
                    return BadRequest("Contact object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                repository.CreateContact(Contact);
                await repository.SaveAsync();
                return CreatedAtRoute("ContactById", new { id = ContactId }, Contact);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] Contact Contact)
        {
            try
            {
                if (Contact == null)
                {
                    return BadRequest("Contact object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var ContactEntity = await repository.GetContactByIdAsync(id);
                if (ContactEntity == null)
                {
                    return NotFound();
                }
                repository.UpdateContact(ContactEntity);
                await repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
