using JwtRoleAuthentication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtRoleAuthentication.Application.Interfaces.Repositories
{
    public interface IPageRepository
    {
        Task<Page> GetByIdAsync(int id);
        Task<IEnumerable<Page>> GetAllAsync();
        Task<Page> AddAsync(Page user);
        Task<Page> UpdateAsync(Page user);
    }
}
