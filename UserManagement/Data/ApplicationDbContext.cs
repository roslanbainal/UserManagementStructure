using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UserManagement.Data.Configurations;
using UserManagement.Data.Seeds;
using UserManagement.Models.Entities;

namespace UserManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<EndPoints> EndPoints { get; set; }
        public DbSet<EndPointRoles> EndPointRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Custom configuration
            Factory.CustomModelCreating(builder);

            //Seed data
            DataSeeder.Create(builder);
        }

        #region Save audit

        public async Task<int> SaveChangesAsync(int currentUserId)
        {
            Audit(currentUserId);
            return await base.SaveChangesAsync();
        }

        private void Audit(int currentUserId)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = currentUserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        entry.Entity.UpdatedBy = currentUserId;
                        break;
                }
            }

        }

        #endregion
    }
}
