using JwtRoleAuthentication.Application.DTOs;
using JwtRoleAuthentication.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtRoleAuthentication.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync(); 
        Task<IdentityResult> CreateAsync(RegistrationRequest request);
        Task<AuthResponse> Authenticate(AuthRequest request);

    }
}
