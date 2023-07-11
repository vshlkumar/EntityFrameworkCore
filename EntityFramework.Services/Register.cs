using EntityFramework.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace EntityFramework.Services
{
    public static class Register
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterAssemblyPublicNonGenericClasses()
             .Where(c => c.Name.EndsWith("Service"))  
             .AsPublicImplementedInterfaces();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            DataRegister.ConfigureDataRepository(services, configuration);
        }
    }
}
