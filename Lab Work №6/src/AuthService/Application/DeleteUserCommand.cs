using Application.Interfaces.Users;
using Domain;

namespace Application
{
    public class DeleteUserCommand : ICommand<Guid>
    {
        private readonly IUserDataProvider _usersProvider;
        private User _lastUpdatedUser;

        public DeleteUserCommand(IUserDataProvider usersProvider)
        {
            _usersProvider = usersProvider;
        }

        public void Execute(Guid userId)
        {
            _lastUpdatedUser = _usersProvider.GetUserAsync(userId).Result;

            _usersProvider.DeleteUser(userId);
        }

        public void Cancel()
        {
            _usersProvider.SaveUser(_lastUpdatedUser);

            _lastUpdatedUser = null;
        }
    }
}
