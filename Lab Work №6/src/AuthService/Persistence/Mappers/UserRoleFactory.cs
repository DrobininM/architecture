using Domain;
using Persistence.Models;

namespace Persistence.Mappers
{
    public class UserRoleFactory
    {
        public static UserRole Create(UserRoleModel userRoleModel)
        {
            if (userRoleModel is null)
            {
                throw new ArgumentNullException("userRoleModel was null.");
            }

            return new UserRole()
            {
                Id = userRoleModel.Id,
                RoleName = userRoleModel.RoleName,
            };
        }

        public static UserRoleModel CreateModel(UserRole user)
        {
            return new UserRoleModel()
            {
                Id = user.Id,
                RoleName = user.RoleName,
            };
        }
    }
}
