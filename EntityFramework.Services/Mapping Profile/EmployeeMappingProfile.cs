using AutoMapper;
using EntityFramework.Domain.Dtos;
using EntityFramework.Domain.Response;

namespace EntityFramework.Services.Mapping_Profile
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile() 
        {
            CreateMap<Employee, EmployeeResponse>()
                .AfterMap((s, d, ctx) =>
                {
                    var mapper = ctx.Mapper;
                    d.Company = mapper.Map<CompanyResponse>(s.Company);
                });
        }
    }
}
