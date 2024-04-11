using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Ns.Application.Contracts.Identity;
using Ns.Application.Models.Identity;
using Ns.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JwtSetings> _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager
            , IOptions<JwtSetings> jwtSettings, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings; 
            _signInManager = signInManager;
        }
        public Task<AuthResponse> Login(AuthRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterationResponse> Register(RegistrationRequest registrationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
