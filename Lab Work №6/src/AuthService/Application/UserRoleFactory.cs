using Application.UserRoles.Commands;
using Domain;

namespace Application
{
    public class UserRoleFactory
    {
        public UserRole Create(CreateUserRoleData roleData)
        {
            return new UserRole
            {
                Id = Guid.NewGuid(),
                RoleName = roleData.RoleName,
            };
        }
    }
}