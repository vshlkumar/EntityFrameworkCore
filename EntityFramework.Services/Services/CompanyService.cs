using EntityFramework.Data.Interface;
using EntityFramework.Domain.Dtos;
using EntityFramework.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company?> AddCompany(Company company)
        {
            var newCompany = await _repository.AddCompany(company);
            if (newCompany)
                return company;

            return null;
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            return await _repository.DeleteCompany(companyId);
        }

        public async Task<List<Company>> GetCompany()
        {
            var companies = await _repository.GetCompany();
            return companies.ToList();
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            return await _repository.UpdateCompany(company);
        }
    }
}
