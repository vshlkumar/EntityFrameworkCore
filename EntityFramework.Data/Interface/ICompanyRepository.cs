using EntityFramework.Domain.Dtos;

namespace EntityFramework.Data.Interface
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompany();
        Task<bool> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<bool> DeleteCompany(int companyId);
    }
}
