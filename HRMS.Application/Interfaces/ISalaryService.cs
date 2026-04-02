using HRMS.Application.Common;
using HRMS.Application.DTOs;

namespace HRMS.Application.Interfaces
{
    public interface ISalaryService
    {
        Task<ApiResponse<SalaryDto>> CalculateSalaryAsync(int employeeId, string month);
    }
}