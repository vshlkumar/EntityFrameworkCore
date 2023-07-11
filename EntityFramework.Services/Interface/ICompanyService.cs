using EntityFramework.Domain.Dtos;

namespace EntityFramework.Services.Interface
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompany();
        Task<Company?> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<bool> DeleteCompany(int companyId);        
    }
}
