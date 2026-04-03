using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public async Task<IActionResult> RecordAttendance([FromBody] AttendanceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _attendanceService.RecordAttendanceAsync(dto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    
    }
}