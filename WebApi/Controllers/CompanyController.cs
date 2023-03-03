using Data.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository repository;

        public CompanyController(ICompanyRepository _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            try
            {
                var company = await repository.GetAllCompanysAsync();
                
                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompanyById(Guid id)
        {
            try
            {
                var Company = await repository.GetCompanyByIdAsync(id);
                if (Company == null)
                {
                    
                    return NotFound();
                }
                else
                {
                  
                    return Ok(Company);
                }
            }
            catch (Exception ex)
            {
         
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetCompanyWithDetails(Guid id)
        {
            try
            {
                var Company = await repository.GetCompanyWithDetailsAsync(id);
                if (Company == null)
                {
                   
                    return NotFound();
                }
                else
                {
               
                    return Ok(CompanyResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            try
            {
                if (company == null)
                {       
                    return BadRequest("Company object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                repository.CreateCompany(company);
                await repository.SaveAsync();
                return CreatedAtRoute("CompanyById", new { id = CompanyId }, company);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] Company company)
        {
            try
            {
                if (company == null)
                {
                    return BadRequest("Company object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var companyEntity = await repository.GetCompanyByIdAsync(id);
                if (companyEntity == null)
                {
                    return NotFound();
                }
                repository.UpdateCompany(companyEntity);
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
