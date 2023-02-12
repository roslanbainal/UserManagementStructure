using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace UserManagement.Models.Entities
{
    [Table("ENDPOINTS")]
    public class EndPoints : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public virtual ICollection<EndPointRoles> EndpointRoles { get; set; } = new List<EndPointRoles>();
        public virtual ICollection<ApplicationRole> ApplicationRoles { get; set; } = new List<ApplicationRole>();
    }
}
