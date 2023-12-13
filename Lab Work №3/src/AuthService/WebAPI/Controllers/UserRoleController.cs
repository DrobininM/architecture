using Application.UserRoles.Commands;
using Application.UserRoles.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly UsersDbContext _dbContext;

        public UserRoleController(UsersDbContext dataAccessProvider)
        {
            _dbContext = dataAccessProvider;
        }

        [HttpGet(nameof(GetAll))]
        public ActionResult<IEnumerable<UserRole>> GetAll()
        {
            var query = new GetAllUserRolesQuery(_dbContext);

            var queryResult = query.Query();

            return Ok(queryResult);
        }

        [HttpPost(nameof(Create))]
        public async Task<ActionResult<UserRole>> Create([FromBody] CreateUserRoleData userRoleData)
        {
            var createCommand = new CreateUserRoleCommand();

            var result = createCommand.Create(userRoleData);

            await _dbContext.Roles.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return Ok(result);
        }
    }
}
