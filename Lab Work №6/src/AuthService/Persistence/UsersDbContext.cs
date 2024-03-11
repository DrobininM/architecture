using Application;
using Application.Interfaces;
using Application.Interfaces.UserRoles;
using Application.Interfaces.Users;
using Domain;
using Microsoft.EntityFrameworkCore;
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

        public UserRole GetUserRole(IFilter<UserRole> filter)
        {
            foreach (var userRole in GetUserRoles())
            {
                if (filter.Filter(userRole))
                {
                    return userRole;
                }
            }

            return null;
        }

        public IEnumerable<User> GetUsers()
        {
            return Users.Include(u => u.Role).Select(userModel => UserFactory.Create(userModel));
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var userModel = await Users.Include(u => u.Role).FirstOrDefaultAsync(user => user.Id == id);

            if (userModel is not null)
            {
                return UserFactory.Create(userModel);
            }

            return null;
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            foreach (var roleModel in Roles)
            {
                yield return Mappers.UserRoleFactory.Create(roleModel);
            }
        }

        public async Task<UserRole> GetUserRoleAsync(Guid id)
        {
            var roleModel = await Roles.FirstOrDefaultAsync(role => role.Id == id);

            if (roleModel is not null)
            {
                return Mappers.UserRoleFactory.Create(roleModel);
            }

            return null;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.UseSerialColumns();
        }

        public void SaveUserRole(UserRole role)
        {
            Roles.Add(Mappers.UserRoleFactory.CreateModel(role));
            SaveChanges();
        }

        public void SaveUser(User user)
        {
            Users.Add(UserFactory.CreateModel(user, this));
            SaveChanges();
        }

        public void UpdateUser(UpdateUserData data)
        {
            var role = GetUserRoleAsync(data.RoleId).Result;

            var user = GetUserAsync(data.UserId).Result;
            user.Name = data.Name;
            user.Password = data.Password;
            user.Role = role;

            SaveChanges();
        }
    }
}
