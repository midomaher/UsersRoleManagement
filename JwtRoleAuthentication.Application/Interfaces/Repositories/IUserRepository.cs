using JwtRoleAuthentication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtRoleAuthentication.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> AddAsync(ApplicationUser user);
        Task<ApplicationUser> UpdateAsync(ApplicationUser user);
    }
}
