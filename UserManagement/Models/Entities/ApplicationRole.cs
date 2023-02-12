using Microsoft.AspNetCore.Identity;

namespace UserManagement.Models.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {
        public virtual ICollection<EndPointRoles> EndpointRoles { get; set; } = new List<EndPointRoles>();
    }
}
