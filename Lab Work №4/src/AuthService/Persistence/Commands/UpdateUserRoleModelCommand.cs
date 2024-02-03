using Domain;
using Persistence.Models;

namespace Persistence.Commands
{
    public class UpdateUserRoleModelCommand
    {
        public UserRoleModel Update(UsersDbContext dbContext, UserRole updatedRole)
        {
            var foundModel = dbContext.Roles.First(roleModel => roleModel.Id == updatedRole.Id);

            foundModel.RoleName = updatedRole.RoleName;

            return foundModel;
        }
    }
}
