using System.ComponentModel.DataAnnotations;

namespace HRMS.Application.DTOs
{
    public class SalaryDto
    {
        [Required(ErrorMessage = "EmployeeId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid EmployeeId")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Month is required")]
        [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])$",
            ErrorMessage = "Month must be in YYYY-MM format")]
        public string Month { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Salary cannot be negative")]
        public decimal TotalSalary { get; set; }
    }
}