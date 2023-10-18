using DotnetAngularBoilerplate.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetAngularBoilerplate.Entity
{
    public class DotnetAngularBoilerplateDbContext : IdentityDbContext<ApplicationUser>
    {
        public DotnetAngularBoilerplateDbContext(DbContextOptions<DotnetAngularBoilerplateDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}