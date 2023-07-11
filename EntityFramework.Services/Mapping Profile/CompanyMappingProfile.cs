using AutoMapper;
using EntityFramework.Domain.Dtos;
using EntityFramework.Domain.Response;

namespace EntityFramework.Services.Mapping_Profile
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyResponse>();
        }
    }
}
