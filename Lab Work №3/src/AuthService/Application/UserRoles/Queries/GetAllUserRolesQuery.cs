using Application.Base.Queries;
using Application.Interfaces.UserRoles;
using Domain;

namespace Application.UserRoles.Queries
{
    public class GetAllUserRolesQuery : BaseQuery<IUserRoleDataProvider>
    {
        public GetAllUserRolesQuery(IUserRoleDataProvider dataProvider)
                    : base(dataProvider)
        {
        }

        public IEnumerable<UserRole> Query()
        {
            return _dataProvider.GetUserRoles();
        }
    }
}
