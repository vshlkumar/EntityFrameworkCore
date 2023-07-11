using EntityFramework.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService= employeeService;
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            return Ok(employees);
        }
    }
}
