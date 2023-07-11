using EntityFramework.Data.Interface;
using EntityFramework.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EntityDbContext _entityDbContext;

        public EmployeeRepository(EntityDbContext entityDbContext) 
        { 
            _entityDbContext= entityDbContext;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _entityDbContext.Employee.Include(x => x.Company).ToListAsync();

            return employees;
        }
    }
}
