using HRMS.Domain.Entities;

namespace HRMS.Application.Interfaces
{
    public interface IAttendanceRepository
    {
        Task AddAsync(Attendance attendance);

        Task<List<Attendance>> GetByEmployeeIdAsync(int employeeId);

        Task<List<Attendance>> GetByEmployeeAndMonthAsync(int employeeId, int month, int year);

        Task<Attendance?> GetByEmployeeAndDateAsync(int employeeId, DateTime date);
    }
}
