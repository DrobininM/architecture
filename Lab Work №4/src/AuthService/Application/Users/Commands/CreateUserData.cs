using System.ComponentModel.DataAnnotations;

namespace Application.Users.Commands
{
    public class CreateUserData
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }
}
