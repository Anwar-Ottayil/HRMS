

using System.ComponentModel.DataAnnotations;

namespace HRMS.Domain.Enum
{
    public enum AttendanceStatus
    {
        [Display(Name = "Present")]
        Present = 1,

        [Display(Name = "Absent")]
        Absent = 2,

        [Display(Name = "Half Day")]
        HalfDay = 3
    }
}
