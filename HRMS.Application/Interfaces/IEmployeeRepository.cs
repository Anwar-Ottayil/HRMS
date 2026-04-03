using HRMS.Domain.Entities;


namespace HRMS.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddAsync(Employee employee);
        
    }
}
