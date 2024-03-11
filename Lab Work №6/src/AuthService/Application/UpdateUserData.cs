using Application.Users.Commands;

namespace Application
{
    public class UpdateUserData : CreateUserData
    {
        public Guid UserId { get; set; }
    }
}
