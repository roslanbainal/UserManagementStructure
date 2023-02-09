using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Entities;

namespace UserManagement.Data.Configurations
{
    public class ApplicationRoleConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "LKP_ROLE");
                entity.Property(p => p.Id).HasColumnName("RoleId");
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable(name: "USER_ROLE");
                entity.Property(p => p.UserId).HasColumnName("UserId");
                entity.Property(p => p.RoleId).HasColumnName("RoleId");
            });
        }
    }
}
