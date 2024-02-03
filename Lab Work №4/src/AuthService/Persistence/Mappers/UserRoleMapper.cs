using Domain;
using Persistence.Models;

namespace Persistence.Mappers
{
    public class UserRoleMapper
    {
        public static UserRole Map(UserRoleModel userRoleModel)
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

        public static UserRoleModel MapToModel(UserRole user)
        {
            return new UserRoleModel()
            {
                Id = user.Id,
                RoleName = user.RoleName,
            };
        }
    }
}
