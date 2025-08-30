using JwtRoleAuthentication.Domain.Models;

namespace JwtRoleAuthentication.Application.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(ApplicationUser user);
    }
}