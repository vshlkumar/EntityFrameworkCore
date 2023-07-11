using EntityFramework.Domain.Dtos;

namespace EntityFramework.Data.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
    }
}
