using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class UserRoleModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
