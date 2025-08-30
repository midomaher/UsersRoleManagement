using JwtRoleAuthentication.Application.Interfaces.Repositories;
using JwtRoleAuthentication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtRoleAuthentication.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> AddAsync(ApplicationUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<IEnumerable<ApplicationUser>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task<ApplicationUser> GetByIdAsync(string id) => await _context.Users.FindAsync(id);
        public async Task<ApplicationUser> GetByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

    }
}
