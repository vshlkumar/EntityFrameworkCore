using EntityFramework.Domain.Response;

namespace EntityFramework.Services.Interface
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponse>> GetEmployees();
    }
}
