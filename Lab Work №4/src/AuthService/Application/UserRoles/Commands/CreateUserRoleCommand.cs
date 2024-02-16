using Application.Interfaces;
using Domain;

namespace Application.UserRoles.Commands
{
    public class CreateUserRoleCommand : ICreateCommand<UserRole, CreateUserRoleData>
    {
        public UserRole Create(CreateUserRoleData data)
        {
            return new UserRole()
            {
                Id = Guid.NewGuid(),
                RoleName = data.RoleName,
            };
        }
    }
}
