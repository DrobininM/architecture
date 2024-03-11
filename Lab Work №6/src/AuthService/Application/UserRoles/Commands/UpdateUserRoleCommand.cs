using Application.Interfaces.UserRoles;
using Domain;

namespace Application.UserRoles.Commands
{
    public class UpdateUserRoleCommand
    {
        private readonly IUserRoleDataProvider _dataProvider;

        public UpdateUserRoleCommand(IUserRoleDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<UserRole> Update(Guid id, CreateUserRoleData userRoleData)
        {
            var userRole = await _dataProvider.GetUserRoleAsync(id);

            if (userRole is null)
            {
                throw new ArgumentException("No user role found with such id.");
            }

            if (userRoleData.RoleName is not null)
            {
                userRole.RoleName = userRoleData.RoleName;
            }

            return userRole;
        }
    }
}
