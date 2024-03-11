using Application.Interfaces;
using Domain;

namespace Application.UserRoles.Filter
{
    public class UserRoleByNameFilter : IFilter<UserRole>
    {
        private readonly string _roleName;

        public UserRoleByNameFilter(string roleId)
        {
            _roleName = roleId;
        }

        public bool Filter(UserRole role)
        {
            return _roleName == role.RoleName;
        }
    }
}
