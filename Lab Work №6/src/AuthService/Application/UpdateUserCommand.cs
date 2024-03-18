using Application.Interfaces.Users;
using Domain;

namespace Application
{
    public class UpdateUserCommand : ICommand<UpdateUserData>
    {
        private readonly IUserDataProvider _usersProvider;
        private User _lastUpdatedUser;

        public UpdateUserCommand(IUserDataProvider usersProvider)
        {
            _usersProvider = usersProvider;
        }

        public void Execute(UpdateUserData parameter)
        {
            _lastUpdatedUser = _usersProvider.GetUserAsync(parameter.UserId).Result;

            _usersProvider.UpdateUser(parameter);
        }

        public void Cancel()
        {
            var updateUserData = new UpdateUserData
            {
                UserId = _lastUpdatedUser.Id,
                Name = _lastUpdatedUser.Name,
                Password = _lastUpdatedUser.Password,
                RoleId = _lastUpdatedUser.Role.Id,
            };

            _usersProvider.UpdateUser(updateUserData);

            _lastUpdatedUser = null;
        }
    }
}
