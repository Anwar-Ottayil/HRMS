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

        public async Task<ApiResponse<List<EmployeeDto>>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeeDtos = employees.Select(e => new EmployeeDto
            {
                Name = e.Name,
                MonthlySalary = e.MonthlySalary
            }).ToList();

            return ApiResponse<List<EmployeeDto>>.SuccessResponse(employeeDtos);
        }

        public async Task<ApiResponse<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            if (id <= 0)
                return ApiResponse<EmployeeDto>.FailResponse("Invalid employee ID");

            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return ApiResponse<EmployeeDto>.FailResponse("Employee not found");

            var employeeDto = new EmployeeDto
            {
                Name = employee.Name,
                MonthlySalary = employee.MonthlySalary
            };

            return ApiResponse<EmployeeDto>.SuccessResponse(employeeDto);
        }
    }
}