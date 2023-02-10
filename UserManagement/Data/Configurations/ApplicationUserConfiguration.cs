using Microsoft.EntityFrameworkCore;
using UserManagement.Models.Entities;

namespace UserManagement.Data.Configurations
{
    public class ApplicationUserConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "MST_USERS");
                entity.Property(p => p.Id).HasColumnName("UserId");
                entity.Property(p => p.PasswordHash).HasColumnName("Password");
            });
        }
    }
}
