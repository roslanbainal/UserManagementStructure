using Microsoft.EntityFrameworkCore;

namespace UserManagement.Data.Configurations
{
    public class Factory
    {
        public static void CustomModelCreating(ModelBuilder builder)
        {
            ApplicationUserConfiguration.Configure(builder);
            ApplicationRoleConfiguration.Configure(builder);
        }
    }
}
