using HRMS.Domain.Entities;

namespace HRMS.Application.Interfaces
{
    public interface IAttendanceRepository
    {
        Task AddAsync(Attendance attendance);
        Task<Attendance?> GetByEmployeeAndDateAsync(int employeeId, DateTime date);
    }
}
