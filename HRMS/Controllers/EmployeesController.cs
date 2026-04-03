using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _employeeService.CreateEmployeeAsync(dto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    }
}