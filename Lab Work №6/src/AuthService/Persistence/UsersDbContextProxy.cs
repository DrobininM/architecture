using Application.Cache;
using Application.Interfaces.Users;
using Domain;

namespace Persistence
{
    public class UsersDbContextProxy : IUserDataProvider
    {
        private readonly IUserDataProvider _usersProvider;
        private readonly CacheService<User> _usersCache;

        public UsersDbContextProxy(IUserDataProvider usersProvider, CacheService<User> usersCache)
        {
            _usersProvider = usersProvider;
            _usersCache = usersCache;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var potentialUser = _usersCache.Get(id);

            if (potentialUser is null)
            {
                potentialUser = await _usersProvider.GetUserAsync(id);

                _usersCache.Add(id, potentialUser);
            }

            return potentialUser;
        }

        public IEnumerable<User> GetUsers()
        {
            return _usersProvider.GetUsers();
        }

        public void SaveUser(User user)
        {
            _usersProvider.SaveUser(user);
        }
    }
}
