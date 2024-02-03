using Domain;
using Persistence.Models;

namespace Persistence.Mappers
{
    public class UserMapper
    {
        public static User Map(UserModel userModel)
        {
            return new User()
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Password = userModel.Password,
                Role = UserRoleMapper.Map(userModel.Role),
                CreationDate = userModel.CreationDate,
            };
        }

        public static UserModel MapToModel(User user, UsersDbContext dbContext)
        {
            return new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Role = dbContext.Roles.FirstOrDefault(roleModel => roleModel.Id == user.Role.Id),
                CreationDate = user.CreationDate,
            };
        }
    }
}
