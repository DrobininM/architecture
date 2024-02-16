using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserRoleModel Role { get; set;}

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
