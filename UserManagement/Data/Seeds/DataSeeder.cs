using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models.Entities;

namespace UserManagement.Data.Seeds
{
    // To add data if table is empty
    public class DataSeeder
    {
        private const string _RoleName = "Super Admin";
        private const string _Email = "admin-st@yopmail.com";
        private const string _Password = "AQAAAAEAACcQAAAAEM3rDxVY2sLJsX6rVxCd6/ZRXZEoZssNlROSGYXy8dskBIVvcYr0JJl2Vd5a+x9+5Q==";

        public static void Create(ModelBuilder builder)
        {
            SeedRole(builder);
            SeedUserAdmin(builder);
        }

        public static void SeedRole(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = 1, 
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Name = _RoleName,
                    NormalizedName = _RoleName.ToUpper()
                }
            );
        }

        public static void SeedUserAdmin(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 1,
                    UserName = _Email,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = _Email,
                    NormalizedEmail = _Email.ToUpper(),
                    NormalizedUserName = _Email.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = true,
                    PasswordHash = _Password
                }
            );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1
                }
            );
        }
    }
}
