using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ns.Application
{
    public static class ApplicationServicesRegisteration
    {
        public static void ConfigureApplicationServices(IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
