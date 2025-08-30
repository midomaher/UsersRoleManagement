using Azure.Core;
using JwtRoleAuthentication.Application.DTOs;
using JwtRoleAuthentication.Application.Interfaces.Repositories;
using JwtRoleAuthentication.Application.Interfaces.Services;
using JwtRoleAuthentication.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtRoleAuthentication.Application.Services
{
    // Services/UserService.cs
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager, ITokenService tokenService, IUserRepository repo)
        {
            _repo = repo;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(u => new UserDto { Id = u.Id, Email = u.Email }).ToList();
        }

        public async Task<IdentityResult> CreateAsync(RegistrationRequest request)
        {
            return await _userManager.CreateAsync(
            new ApplicationUser { UserName = request.Username, Email = request.Email },
            request.Password!
        );
        }

        public async Task<AuthResponse> Authenticate(AuthRequest request)
        {
            var managedUser = await _userManager.FindByEmailAsync(request.Email!);

            if (managedUser == null || string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password!);

            if (!isPasswordValid)
            {
                throw new Exception("Bad credentials");
            }

            var userInDb = await _repo.GetByEmailAsync(request.Email);

            if (userInDb is null)
            {
                throw new UnauthorizedAccessException();

            }

            var accessToken = await _tokenService.CreateToken(userInDb);
            await _repo.UpdateAsync(userInDb);
            return new AuthResponse
            {
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Token = accessToken,
            };
        }
    }
}
