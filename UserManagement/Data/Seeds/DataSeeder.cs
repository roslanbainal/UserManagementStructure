using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Entities;

namespace UserManagement.Data.Seeds
{
    // To add data if table is empty
    public class DataSeeder
    {
        private const string ROLENAME = "Super Admin";
        private const string EMAIL = "admin-st@yopmail.com";
        private const string PASSWORD = "AQAAAAEAACcQAAAAEM3rDxVY2sLJsX6rVxCd6/ZRXZEoZssNlROSGYXy8dskBIVvcYr0JJl2Vd5a+x9+5Q==";

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
                    Name = ROLENAME,
                    NormalizedName = ROLENAME.ToUpper()
                }
            );
        }

        public static void SeedUserAdmin(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 1,
                    UserName = EMAIL,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = EMAIL,
                    NormalizedEmail = EMAIL.ToUpper(),
                    NormalizedUserName = EMAIL.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = true,
                    PasswordHash = PASSWORD
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
