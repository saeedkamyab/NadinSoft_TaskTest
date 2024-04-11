using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Ns.Application.Contracts.Identity;
using Ns.Application.Models.Identity;
using Ns.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Ns.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSetings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager
            , JwtSetings jwtSettings, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _signInManager = signInManager;
        }
        public async Task<AuthResponse> Login(AuthRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                throw new Exception($"there is no {loginRequest.Email} email!");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginRequest.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
                throw new Exception("Login Faild!");
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            AuthResponse response = new AuthResponse()
            {
                Id=user.Id,
                Token=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email=loginRequest.Email,
                UserName=user.UserName,

            };
       return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.UserName),
                new Claim("uid",user.Id),
            }.Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;

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
