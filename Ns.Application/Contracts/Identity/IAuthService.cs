using Ns.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest loginRequest);

        Task<RegisterationResponse> Register(RegistrationRequest registrationRequest);

    }
}
