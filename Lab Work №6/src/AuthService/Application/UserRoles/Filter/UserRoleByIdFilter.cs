using Application.Interfaces;
using Domain;

namespace Application.UserRoles.Filter
{
    public class UserRoleByIdFilter : IFilter<UserRole>
    {
        private readonly Guid _roleId;

        public UserRoleByIdFilter(Guid roleId)
        {
            _roleId = roleId;
        }

        public bool Filter(UserRole role)
        {
            return _roleId == role.Id;
        }
    }
}
