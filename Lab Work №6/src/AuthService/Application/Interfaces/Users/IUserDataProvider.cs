using Domain;

namespace Application.Interfaces.Users
{
    public interface IUserDataProvider
    {
        IEnumerable<User> GetUsers();

        Task<User> GetUserAsync(Guid id);

        void SaveUser(User user);

        void UpdateUser(UpdateUserData data);

        void DeleteUser(Guid id);
    }
}
