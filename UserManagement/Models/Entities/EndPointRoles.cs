using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Entities
{
    [Table("ENDPOINT_ROLES")]
    public class EndPointRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EndPointsId { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; } = new();
        [ForeignKey("EndPointsId")]
        public virtual EndPoints EndPoint { get; set; } = new();
    }
}
