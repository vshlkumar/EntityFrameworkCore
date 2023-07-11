using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace EntityFramework.Data
{
    public static class DataRegister
    {
        public static void ConfigureDataRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EntityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.RegisterAssemblyPublicNonGenericClasses()
                .Where(x => x.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces();
        }
    }
}
