using Application.Interfaces.UserRoles;
using Application.Interfaces.Users;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations;
using Persistence.Mappers;
using Persistence.Models;

namespace Persistence
{
    public class UsersDbContext : DbContext, IUserDataProvider, IUserRoleDataProvider
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<UserRoleModel> Roles { get; set; }

        public IEnumerable<User> GetUsers()
        {
            return Users.Include(u => u.Role).Select(userModel => UserMapper.Map(userModel));
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var userModel = await Users.Include(u=> u.Role).FirstOrDefaultAsync(user => user.Id == id);

            if (userModel is not null)
            {
                return UserMapper.Map(userModel);
            }

            return null;
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            return Roles.Select(UserRoleMapper.Map);
        }

        public async Task<UserRole> GetUserRoleAsync(Guid id)
        {
            var roleModel = await Roles.FirstOrDefaultAsync(role => role.Id == id);

            if (roleModel is not null)
            {
                return UserRoleMapper.Map(roleModel);
            }

            return null;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.UseSerialColumns();
        }
    }
}
