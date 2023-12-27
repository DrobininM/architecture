using Domain;

namespace Application.Interfaces.Users
{
    public interface IUserDataProvider
    {
        IEnumerable<User> GetUsers();

        Task<User> GetUserAsync(Guid id);
    }
}
