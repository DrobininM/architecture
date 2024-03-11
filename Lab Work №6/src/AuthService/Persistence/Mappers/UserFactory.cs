using Application.Interfaces.UserRoles;
using Domain;
using Persistence.Models;

namespace Persistence.Mappers
{
    public class UserFactory
    {
        public static User Create(UserModel userModel)
        {
            return new User()
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Password = userModel.Password,
                Role = UserRoleFactory.Create(userModel.Role),
                CreationDate = userModel.CreationDate,
            };
        }

        public static UserModel CreateModel(User user, IUserRoleDataProvider rolesProvider)
        {
            var userRole = rolesProvider.GetUserRole(roleModel => roleModel.Id == user.Role.Id);
            var userRoleModel = UserRoleFactory.CreateModel(userRole);

            return new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Role = userRoleModel,
                CreationDate = user.CreationDate,
            };
        }
    }
}
