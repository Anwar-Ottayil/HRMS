using HRMS.Application.Common;
using HRMS.Application.DTOs;

namespace HRMS.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<ApiResponse<int>> CreateEmployeeAsync(EmployeeDto dto);
        Task<ApiResponse<List<EmployeeDto>>> GetAllEmployeesAsync();
        Task<ApiResponse<EmployeeDto>> GetEmployeeByIdAsync(int id);
    }
}