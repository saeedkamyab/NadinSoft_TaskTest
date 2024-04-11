using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ns.Application.Contracts.Persistence;
using Ns.Application.Contracts.Persistence.Common;
using Ns.Persistence.Repositories;
using Ns.Persistence.Repositories.Common;

namespace Ns.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices
            (this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<NsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            
      

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IProductRepository,ProductRepository>();

            return services;
        }
    }
}
