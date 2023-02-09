using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Configurations;
using UserManagement.Data.Entities;
using UserManagement.Data.Seeds;

namespace UserManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Custom configuration
            Factory.CustomModelCreating(builder);

            //Seed data
            DataSeeder.Create(builder);
        }
    }
}
