using System.ComponentModel.DataAnnotations;

namespace HRMS.Application.DTOs
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Monthly salary is required")]
        [Range(1, 1000000, ErrorMessage = "Salary must be greater than 0")]
        public decimal MonthlySalary { get; set; }
    }
}