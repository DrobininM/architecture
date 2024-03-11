using Domain;

namespace Application.Interfaces.UserRoles
{
    public interface IUserRoleDataProvider
    {
        IEnumerable<UserRole> GetUserRoles();

        Task<UserRole> GetUserRoleAsync(Guid id);

        UserRole GetUserRole(IFilter<UserRole> filter);

        void SaveUserRole(UserRole role);
    }
}