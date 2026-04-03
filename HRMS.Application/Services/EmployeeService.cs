using HRMS.Application.Common;
using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;

namespace HRMS.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ApiResponse<int>> CreateEmployeeAsync(EmployeeDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return ApiResponse<int>.FailResponse("Employee name is required");

            if (dto.MonthlySalary <= 0)
                return ApiResponse<int>.FailResponse("Salary must be greater than zero");

            var employee = new Employee
            {
                Name = dto.Name,
                MonthlySalary = dto.MonthlySalary
            };

            var result = await _employeeRepository.AddAsync(employee);

            return ApiResponse<int>.SuccessResponse(result.Id, "Employee created successfully");
        }

       
    }
}