using Application.Encrypt;
using Application.Interfaces.Users;
using Domain;

namespace Persistence
{
    public class EncryptUsersDb : IUserDataProvider
    {
        private readonly IUserDataProvider _usersProvider;

        public EncryptUsersDb(IUserDataProvider usersProvider)
        {
            _usersProvider = usersProvider;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _usersProvider.GetUserAsync(id);

            user.Password = CipherService.Decrypt(user.Password);

            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _usersProvider.GetUsers().ToList();

            users.ForEach(user => user.Password = CipherService.Decrypt(user.Password));

            return users;
        }

        public void SaveUser(User user)
        {
            user.Password = CipherService.Encrypt(user.Password);

            _usersProvider.SaveUser(user);
        }
    }
}
