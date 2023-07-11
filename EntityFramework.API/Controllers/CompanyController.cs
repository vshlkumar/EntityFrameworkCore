using EntityFramework.Domain.Dtos;
using EntityFramework.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.API.Controllers
{
    [Route("api/v1")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _service; 
        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet("company")]
        public async Task<IActionResult> GetCompany()
        {
            var companies = await _service.GetCompany();
            return Ok(companies);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCompany(Company company)
        {
            var newCompany = await _service.AddCompany(company);
            return Ok(newCompany);
        }

        [HttpDelete("delete/{companyId}")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            var isDeleted = await _service.DeleteCompany(companyId);
            if (isDeleted)
                return Ok("Company deleted successfully");

            return BadRequest("Please try again to delete company");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCompany(Company company)
        {
            var updatedCompany = await _service.UpdateCompany(company);
            return Ok(updatedCompany);
        }        
    }
}
