using HRMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        public async Task<IActionResult> CalculateSalary(int employeeId, string month)
        {
            
            if (employeeId <= 0)
                return BadRequest("Invalid Employee Id");

            if (string.IsNullOrWhiteSpace(month))
                return BadRequest("Month is required. Format: YYYY-MM");

            var response = await _salaryService.CalculateSalaryAsync(employeeId, month);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}