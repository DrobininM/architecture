using Domain;

namespace Application.Handlers
{
    public class CheckUserNameHandler : ICheckHandler<User>
    {
        public ICheckHandler<User> Successor { get; set; }

        public bool Handle(User value)
        {
            return value.Name.Length > 1 && Successor?.Handle(value) == true;
        }
    }
}
