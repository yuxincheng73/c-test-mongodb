using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TCC.Authorization.Roles;
using TCC.Authorization.Users;
using TCC.MultiTenancy;
using TCC.Models;

namespace TCC.EntityFrameworkCore
{
    public class TCCDbContext : AbpZeroDbContext<Tenant, Role, User, TCCDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Brands> Brands { get; set; }
        
        public TCCDbContext(DbContextOptions<TCCDbContext> options)
            : base(options)
        {
        }
    }
}
