using DotnetAngularBoilerplate.Model;
using Microsoft.AspNetCore.Identity;
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
            SeedRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "GlobalAdmin", ConcurrencyStamp = "1", NormalizedName = "GlobalAdmin" },
                    new IdentityRole { Name = "Admin", ConcurrencyStamp = "2", NormalizedName = "Admin" },
                    new IdentityRole { Name = "Manager", ConcurrencyStamp = "3", NormalizedName = "Manager" },
                    new IdentityRole { Name = "Analyst", ConcurrencyStamp = "4", NormalizedName = "Analyst" }
                );
        }
    }
}