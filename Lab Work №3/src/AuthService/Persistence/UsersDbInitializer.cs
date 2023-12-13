namespace Persistence
{
    public class UsersDbInitializer
    {
        public static void Initialize(UsersDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
