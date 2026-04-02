using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRMS.Domain.Enum;

namespace HRMS.Domain.Entities
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeId must be greater than 0")]
        public int EmployeeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public AttendanceStatus Status { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } = null!;
    }
}
