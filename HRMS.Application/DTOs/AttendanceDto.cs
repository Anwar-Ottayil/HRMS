using System.ComponentModel.DataAnnotations;
using HRMS.Domain.Enum;

namespace HRMS.Application.DTOs
{
    public class AttendanceDto
    {
        [Required(ErrorMessage = "EmployeeId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid EmployeeId")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [EnumDataType(typeof(AttendanceStatus), ErrorMessage = "Invalid attendance status")]
        public AttendanceStatus Status { get; set; }
    }
}
