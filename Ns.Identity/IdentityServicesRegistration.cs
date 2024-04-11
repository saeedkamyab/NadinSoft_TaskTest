using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ns.Application.Contracts.Identity;
using Ns.Application.Models.Identity;
using Ns.Identity.Models;
using Ns.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSetings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<NsIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IAuthService, AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer=true,
                    ValidateAudience=true,
                    ValidateLifetime=true,
                ClockSkew=TimeSpan.Zero,
                };
            });

            return services;
        }
    }
}
