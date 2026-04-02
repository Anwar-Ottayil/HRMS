using HRMS.Application.Common;
using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using HRMS.Domain.Enum;

namespace HRMS.Application.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public async Task<ApiResponse<SalaryDto>> CalculateSalaryAsync(int employeeId, string month)
        {
            if (employeeId <= 0)
                return ApiResponse<SalaryDto>.FailResponse("Invalid EmployeeId");

            if (string.IsNullOrWhiteSpace(month))
                return ApiResponse<SalaryDto>.FailResponse("Month is required");

            if (!DateTime.TryParse(month + "-01", out DateTime monthDate))
                return ApiResponse<SalaryDto>.FailResponse("Invalid month format. Use YYYY-MM");

            var employee = await _salaryRepository.GetEmployeeAsync(employeeId);
            if (employee == null)
                return ApiResponse<SalaryDto>.FailResponse("Employee not found");

            var attendances = await _salaryRepository
                .GetAttendanceAsync(employeeId, monthDate);

            if (attendances == null || attendances.Count == 0)
                return ApiResponse<SalaryDto>.FailResponse("No attendance data found for this month");

            int presentDays = attendances.Count(a => a.Status == AttendanceStatus.Present);
            int halfDays = attendances.Count(a => a.Status == AttendanceStatus.HalfDay);

            decimal perDaySalary = employee.MonthlySalary / 30;

            decimal totalSalary =
                (presentDays * perDaySalary) +
                (halfDays * perDaySalary * 0.5m);

            var result = new SalaryDto
            {
                EmployeeId = employeeId,
                Month = month,
                TotalSalary = Math.Round(totalSalary, 2)
            };

            return ApiResponse<SalaryDto>.SuccessResponse(result, "Salary calculated successfully");
        }
    }
}