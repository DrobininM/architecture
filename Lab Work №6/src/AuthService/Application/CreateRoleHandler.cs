using Application.Interfaces.UserRoles;
using Application.UserRoles.Commands;

namespace Application
{
    public class CreateRoleHandler : IRequestHandler
    {
        private readonly IUserRoleDataProvider _rolesProvider;

        public CreateRoleHandler(IUserRoleDataProvider rolesProvider)
        {
            _rolesProvider = rolesProvider;
        }

        public Type ParameterType => typeof(CreateUserRoleData);

        public void Handle(object parameter)
        {
            var userData = (CreateUserRoleData) parameter;
            var user = new UserRoleFactory().Create(userData);

            _rolesProvider.SaveUserRole(user);
        }
    }
}
