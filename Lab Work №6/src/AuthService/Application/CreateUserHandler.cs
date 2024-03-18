using Application.Interfaces.UserRoles;
using Application.Interfaces.Users;
using Application.Users.Commands;

namespace Application
{
    public class CreateUserHandler : IRequestHandler
    {
        private readonly IUserDataProvider _usersProvider;
        private readonly IUserRoleDataProvider _rolesProvider;

        public CreateUserHandler(IUserDataProvider usersProvider, IUserRoleDataProvider rolesProvider)
        {
            _usersProvider = usersProvider;
            _rolesProvider = rolesProvider;
        }

        public Type ParameterType => typeof(CreateUserData);

        public void Handle(object parameter)
        {
            var userData = (CreateUserData) parameter;
            var user = new UserFactory(_rolesProvider).Create(userData);

            _usersProvider.SaveUser(user);
        }
    }
}
