using Data.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CountryController : Controller
    {
         private readonly CompanyRepoistory repository;

        public CountryController(CompanyRepoistory _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCountry()
        {
            try
            {
                var Country = await repository.GetAllCountrysAsync();

                return Ok(Country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "CountryById")]
        public async Task<IActionResult> GetCountryById(Guid id)
        {
            try
            {
                var Country = await repository.GetCountryByIdAsync(id);
                if (Country == null)
                {

                    return NotFound();
                }
                else
                {

                    return Ok(Country);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetCountryWithDetails(Guid id)
        {
            try
            {
                var country = await repository.GetCountryWithDetailsAsync(id);
                if (country == null)
                {

                    return NotFound();
                }
                else
                {

                    return Ok(country);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] Country Country)
        {
            try
            {
                if (Country == null)
                {
                    return BadRequest("Country object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                repository.CreateCountry(Country);
                await repository.SaveAsync();
                return CreatedAtRoute("CountryById", new { id = CountryId }, Country);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(Guid id, [FromBody] Country Country)
        {
            try
            {
                if (Country == null)
                {
                    return BadRequest("Country object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var CountryEntity = await repository.GetCountryByIdAsync(id);
                if (CountryEntity == null)
                {
                    return NotFound();
                }
                repository.UpdateCountry(CountryEntity);
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
