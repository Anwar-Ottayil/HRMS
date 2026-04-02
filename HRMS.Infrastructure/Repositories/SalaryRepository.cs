using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace HRMS.Infrastructure.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly AppDbContext _context;

        public SalaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployeeAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task<List<Attendance>> GetAttendanceAsync(int employeeId, DateTime month)
        {
            return await _context.Attendances
                .Where(a => a.EmployeeId == employeeId &&
                            a.Date.Month == month.Month &&
                            a.Date.Year == month.Year)
                .ToListAsync();
        }
    }
}
