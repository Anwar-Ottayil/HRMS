using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using HRMS.Application.Common;
using HRMS.Domain.Entities;

namespace HRMS.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<ApiResponse<string>> RecordAttendanceAsync(AttendanceDto dto)
        {
            if (dto.EmployeeId <= 0)
                return ApiResponse<string>.FailResponse("Invalid EmployeeId");

            if (dto.Date > DateTime.Today)
                return ApiResponse<string>.FailResponse("Attendance date cannot be in the future");

            var existing = await _attendanceRepository
                .GetByEmployeeAndDateAsync(dto.EmployeeId, dto.Date);

            if (existing != null)
                return ApiResponse<string>.FailResponse("Attendance already recorded for this date");

            var attendance = new Attendance
            {
                EmployeeId = dto.EmployeeId,
                Date = dto.Date,
                Status = dto.Status
            };

            await _attendanceRepository.AddAsync(attendance);

            return ApiResponse<string>.SuccessResponse(null, "Attendance recorded successfully");
        }

        public async Task<ApiResponse<List<AttendanceDto>>> GetAttendanceByEmployeeAsync(int employeeId)
        {
            if (employeeId <= 0)
                return ApiResponse<List<AttendanceDto>>.FailResponse("Invalid EmployeeId");

            var attendances = await _attendanceRepository.GetByEmployeeIdAsync(employeeId);

            var result = attendances.Select(a => new AttendanceDto
            {
                EmployeeId = a.EmployeeId,
                Date = a.Date,
                Status = a.Status
            }).ToList();

            return ApiResponse<List<AttendanceDto>>.SuccessResponse(result);
        }
    }
}