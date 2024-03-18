using Domain;

namespace Application.Handlers
{
    public static class CheckUserHandlerConfigurator
    {
        public static ICheckHandler<User> CreateCheckUserHandler()
        {
            var passwordHandler = new CheckPasswordHandler();
            var userNameHandler = new CheckUserNameHandler();

            passwordHandler.Successor = userNameHandler;

            return passwordHandler;
        }
    }
}
