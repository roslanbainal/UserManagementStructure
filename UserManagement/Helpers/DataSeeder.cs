using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Entities;

namespace UserManagement.Helpers
{
    // To add data if table is empty
    public class DataSeeder
    {
        public static void SeedRole(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = 1, ConcurrencyStamp = Guid.NewGuid().ToString(), Name = "Super Admin", NormalizedName = "SUPER ADMIN" }
            );
        }

        public static void SeedUserAdmin(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 1,
                    UserName = "admin-st@yopmail.com",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "admin-st@yopmail.com",
                    NormalizedEmail = "admin-st@yopmail.com".ToUpper(),
                    NormalizedUserName = "admin-st@yopmail.com".ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEM3rDxVY2sLJsX6rVxCd6/ZRXZEoZssNlROSGYXy8dskBIVvcYr0JJl2Vd5a+x9+5Q=="
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
