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

        public async Task<RegisterationResponse> Register(RegistrationRequest registrationRequest)
        {
            var existingUser = await _userManager.FindByNameAsync(registrationRequest.UserName);
            if (existingUser != null)
            {
                throw new Exception($"user name '{registrationRequest.UserName}' is already exsist!");
            }

            var user = new ApplicationUser
            {
                Email = registrationRequest.Email,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                UserName = registrationRequest.UserName,

            };

            var existingEmail = await _userManager.FindByEmailAsync(registrationRequest.Email);
            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, registrationRequest.Password);
                if (result.Succeeded)
                {
                    return new RegisterationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email '{registrationRequest.Email}' is already exsist!");

            }

        }
    }
}
