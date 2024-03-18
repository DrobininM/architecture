using Application.Interfaces.UserRoles;
using Application.Users.Commands;
using Domain;

namespace Application.Users
{
    public class UserFacade
    {
        private readonly IUserRoleDataProvider _rolesProvider;

        public UserFacade(IUserRoleDataProvider rolesProvider)
        {
            _rolesProvider = rolesProvider;
        }

        public User CreateAdmin(string userName, string password)
        {
            var role = _rolesProvider.GetUserRole(role => role.RoleName == Constants.AdminRoleName);

            if (role is null)
            {
                role = new UserRole
                {
                    RoleName = Constants.AdminRoleName,
                };

                _rolesProvider.SaveUserRole(role);
            }

            return Create(userName, password, role);
        }
        public User CreateDefaultUser(string userName, string password)
        {
            var role = _rolesProvider.GetUserRole(role => role.RoleName == Constants.DefaultUserRole);

            if (role is null)
            {
                role = new UserRole
                {
                    RoleName = Constants.DefaultUserRole,
                };

                _rolesProvider.SaveUserRole(role);
            }

            return Create(userName, password, role);
        }

        private User Create(string userName, string password, UserRole role)
        {
            var adminData = new CreateUserData
            {
                Name = userName,
                Password = password,
                RoleId = role.Id,
            };

            return new UserFactory(_rolesProvider).Create(adminData);
        }
    }
}
