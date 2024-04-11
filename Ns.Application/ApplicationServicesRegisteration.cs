using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ns.Application
{
    public static class ApplicationServicesRegisteration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
