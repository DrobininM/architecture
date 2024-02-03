using Application.Base.Queries;
using Application.Interfaces.Users;
using Domain;

namespace Application.Users.Queries
{
    public class GetUserQuery : BaseQuery<IUserDataProvider>
    {
        public GetUserQuery(IUserDataProvider dataProvider)
            : base(dataProvider)
        {
        }

        public async Task<User> Query(Guid id)
        {
            return await _dataProvider.GetUserAsync(id);
        }
    }
}
