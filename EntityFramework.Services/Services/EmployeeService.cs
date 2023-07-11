using AutoMapper;
using EntityFramework.Data.Interface;
using EntityFramework.Domain.Dtos;
using EntityFramework.Domain.Response;
using EntityFramework.Services.Interface;

namespace EntityFramework.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;        
        private readonly IMapper _mapper;   

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) 
        { 
            _employeeRepository= employeeRepository;
            _mapper= mapper;
        }

        public async Task<List<EmployeeResponse>> GetEmployees()
        {
            var employeesFromDb = await _employeeRepository.GetEmployees();
            return _mapper.Map<List<EmployeeResponse>>(employeesFromDb.ToList());
        }
    }
}
