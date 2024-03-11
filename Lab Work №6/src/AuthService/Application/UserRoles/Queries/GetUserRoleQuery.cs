using Application.Base.Queries;
using Application.Interfaces.UserRoles;
using Domain;

namespace Application.UserRoles.Queries
{
    public class GetUserRoleQuery : BaseQuery<IUserRoleDataProvider>
    {
        public GetUserRoleQuery(IUserRoleDataProvider dataProvider)
                    : base(dataProvider)
        {
        }

        public async Task<UserRole> Query(Guid id)
        {
            return await _dataProvider.GetUserRoleAsync(id);
        }
    }
}
