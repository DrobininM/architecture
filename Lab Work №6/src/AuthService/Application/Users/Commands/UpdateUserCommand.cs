using Application.Interfaces.UserRoles;
using Application.Interfaces.Users;
using Domain;

namespace Application.Users.Commands
{
    public class UpdateUserCommand
    {
        private readonly IUserDataProvider _usersProvider;
        private readonly IUserRoleDataProvider _userRolesProvider;

        public UpdateUserCommand(IUserDataProvider usersProvider, IUserRoleDataProvider userRolesProvider)
        {
            _usersProvider = usersProvider;
            _userRolesProvider = userRolesProvider;
        }

        public async Task<User> Update(Guid userId, CreateUserData userData)
        {
            var user = await _usersProvider.GetUserAsync(userId);

            if (user is null)
            {
                throw new ArgumentException("No user found with such id.");
            }

            if (userData.Name is not null)
            {
                user.Name = userData.Name;
            }

            if (userData.Password is not null)
            {
                user.Password = userData.Password;
            }

            var userRole = await _userRolesProvider.GetUserRoleAsync(userData.RoleId);

            if (userRole is not null)
            {
                user.Role = userRole;
            }

            return user;
        }
    }
}
