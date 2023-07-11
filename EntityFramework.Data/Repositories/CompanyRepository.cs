using EntityFramework.Data.Interface;
using EntityFramework.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly EntityDbContext _dbContext;
        public CompanyRepository(EntityDbContext entityDb)
        {
            _dbContext = entityDb;
        }

        public async Task<List<Company>> GetCompany()
        {
            return await _dbContext.Company.ToListAsync();
        }

        public async Task<bool> AddCompany(Company company)
        {
            await _dbContext.Company.AddAsync(company);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            var company = await _dbContext.Company.Where(x => x.Id == companyId).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
            if (company > 0)
                return true;

            return false;
        }
            
        public async Task<Company> UpdateCompany(Company company)
        {
            var companyInDb = await _dbContext.Company.FirstOrDefaultAsync(x => x.Id == company.Id);
            if(companyInDb != null)
            {
                companyInDb.Name = company.Name;
                companyInDb.IsActive = company.IsActive;
                _dbContext.Company.Update(companyInDb);
                await _dbContext.SaveChangesAsync();

                return companyInDb;
            }
            return company;
        }
    }
}
