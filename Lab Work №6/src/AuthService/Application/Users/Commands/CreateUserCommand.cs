using Domain;
using Application.Interfaces;
using Application.Interfaces.UserRoles;
using Application.UserRoles.Queries;

namespace Application.Users.Commands
{
    public class UserFactory : ICreateCommand<User, CreateUserData>
    {
        private readonly IUserRoleDataProvider _rolesProvider;

        public UserFactory(IUserRoleDataProvider rolesProvider)
        {
            _rolesProvider = rolesProvider;
        }

        public User Create(CreateUserData data)
        {
            var findRoleQuery = new GetUserRoleQuery(_rolesProvider);
            var role = findRoleQuery.Query(data.RoleId).Result;

            if (role is null)
            {
                throw new ArgumentException("Not found role for id " + data.RoleId);
            }

            return new User()
            {
                Id = Guid.NewGuid(),
                Name = data.Name,
                Password = data.Password,
                Role = role,
                CreationDate = DateTime.Now.ToUniversalTime(),
            };
        }
    }
}
