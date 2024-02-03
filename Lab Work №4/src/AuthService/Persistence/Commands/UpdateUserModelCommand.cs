using Domain;
using Persistence.Models;

namespace Persistence.Commands
{
    public class UpdateUserModelCommand
    {
        public UserModel Update(UsersDbContext dbContext, User updatedUser)
        {
            var foundModel = dbContext.Users.First(userModel => userModel.Id == updatedUser.Id);

            foundModel.Name = updatedUser.Name;
            foundModel.Role = dbContext.Roles.First(roleModel => roleModel.Id == updatedUser.Role.Id);
            foundModel.Password = updatedUser.Password;

            return foundModel;
        }
    }
}
