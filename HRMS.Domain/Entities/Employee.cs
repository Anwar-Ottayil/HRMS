using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Domain.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 1000000)]
        public decimal MonthlySalary { get; set; }

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}