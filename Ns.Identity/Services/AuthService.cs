using Ns.Application.Contracts.Identity;
using Ns.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Identity.Services
{
    public class AuthService : IAuthService
    {
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
