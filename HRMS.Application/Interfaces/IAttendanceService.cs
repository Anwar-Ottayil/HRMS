using HRMS.Application.Common;
using HRMS.Application.DTOs;

public interface IAttendanceService
{
    Task<ApiResponse<string>> RecordAttendanceAsync(AttendanceDto dto);
    Task<ApiResponse<List<AttendanceDto>>> GetAttendanceByEmployeeAsync(int employeeId);
}