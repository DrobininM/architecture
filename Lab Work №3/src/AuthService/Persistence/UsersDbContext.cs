using Application.Interfaces.UserRoles;
using Application.Interfaces.Users;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations;

namespace Persistence
{
    public class UsersDbContext : DbContext, IUserDataProvider, IUserRoleDataProvider
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> Roles { get; set; }

        public IEnumerable<User> GetUsers()
        {
            return Users;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            return Roles;
        }

        public async Task<UserRole> GetUserRoleAsync(Guid id)
        {
            return await Roles.FirstOrDefaultAsync(role => role.Id == id);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.UseSerialColumns();
        }
    }
}
