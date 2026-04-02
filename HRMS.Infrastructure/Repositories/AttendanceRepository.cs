using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Attendance>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.Attendances
                .AsNoTracking()
                .Where(a => a.EmployeeId == employeeId)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<List<Attendance>> GetByEmployeeAndMonthAsync(int employeeId, int month, int year)
        {
            return await _context.Attendances
                .AsNoTracking()
                .Where(a => a.EmployeeId == employeeId &&
                            a.Date.Month == month &&
                            a.Date.Year == year)
                .ToListAsync();
        }

        public async Task<Attendance?> GetByEmployeeAndDateAsync(int employeeId, DateTime date)
        {
            return await _context.Attendances
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.EmployeeId == employeeId &&
                                          a.Date.Date == date.Date);
        }
    }
}