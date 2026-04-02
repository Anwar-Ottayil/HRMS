using HRMS.Domain.Entities;


namespace HRMS.Application.Interfaces
{
    public interface ISalaryRepository
    {
        Task<Employee?> GetEmployeeAsync(int employeeId);
        Task<List<Attendance>> GetAttendanceAsync(int employeeId, DateTime month);
    }
   
}
