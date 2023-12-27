using Application.Users.Commands;
using Application.Users.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UsersDbContext _dbContext;

        public UserController(UsersDbContext dataAccessProvider)
        {
            _dbContext = dataAccessProvider;
        }

        [HttpGet(nameof(GetAll))]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var query = new GetAllUsersQuery(_dbContext);

            var queryResult = query.Query();

            return Ok(queryResult);
        }

        [HttpPost(nameof(Create))]
        public async Task<ActionResult<UserRole>> Create([FromBody] CreateUserData userData)
        {
            var createCommand = new CreateUserCommand(_dbContext);

            var result = createCommand.Create(userData);

            await _dbContext.Users.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return Ok(result);
        }
    }
}
