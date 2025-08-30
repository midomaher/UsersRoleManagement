using JwtRoleAuthentication.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtRoleAuthentication.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Page> Pages => Set<Page>();
    
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}