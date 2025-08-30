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
    public class PageRepository : IPageRepository
    {
        private readonly ApplicationDbContext _context;
        public PageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Page> AddAsync(Page page)
        {
           _context.Pages.Add(page);
           await _context.SaveChangesAsync();
            return page;
        }

        public async Task<IEnumerable<Page>> GetAllAsync() => await _context.Pages.ToListAsync();
      

        public async Task<Page> GetByIdAsync(int id) => await _context.Pages.FindAsync(id);
        

        public  async Task<Page> UpdateAsync(Page page)
        {
            _context.Pages.Update(page);
           await _context.SaveChangesAsync();
            return page;
        }
    }
}
