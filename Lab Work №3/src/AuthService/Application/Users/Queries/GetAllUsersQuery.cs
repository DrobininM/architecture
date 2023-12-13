using Application.Base.Queries;
using Application.Interfaces.Users;
using Domain;

namespace Application.Users.Queries
{
    public class GetAllUsersQuery : BaseQuery<IUserDataProvider>
    {
        public GetAllUsersQuery(IUserDataProvider dataProvider)
            : base(dataProvider)
        {
        }

        public IEnumerable<User> Query()
        {
            return _dataProvider.GetUsers();
        }
    }
}
