using Domain;

namespace Application.Handlers
{
    public class CheckPasswordHandler : ICheckHandler<User>
    {
        public ICheckHandler<User> Successor { get; set; }

        public bool Handle(User user)
        {
            return user.Password.Length > 6 && Successor?.Handle(user) == true;
        }
    }
}
