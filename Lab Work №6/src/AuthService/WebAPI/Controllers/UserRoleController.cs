using Application.UserRoles.Commands;
using Application.UserRoles.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Commands;
using Persistence.Mappers;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/userRoles")]
    public class UserRoleController : ControllerBase
    {
        private readonly UsersDbContext _dbContext;

        public UserRoleController(UsersDbContext dataAccessProvider)
        {
            _dbContext = dataAccessProvider;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserRole>> Get()
        {
            var query = new GetAllUserRolesQuery(_dbContext);

            try
            {
                var queryResult = query.Query();

                if (queryResult is null)
                {
                    return NoContent();
                }

                return Ok(queryResult);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> Get(Guid? id)
        {
            if (id is null)
            {
                return ValidationProblem("The provided id is not compatible.");
            }

            var query = new GetUserRoleQuery(_dbContext);

            try
            {
                var queryResult = await query.Query(id.Value);

                if (queryResult is null)
                {
                    return NotFound("No user role found with such id.");
                }

                return Ok(queryResult);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserRole>> Create([FromBody] CreateUserRoleData userData)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem("Didn't get these parameters to complete the request: " + String.Join(", ", ModelState.Keys));
            }

            var createCommand = new CreateUserRoleCommand();

            try
            {
                var result = createCommand.Create(userData);

                await _dbContext.Roles.AddAsync(UserRoleFactory.CreateModel(result));
                await _dbContext.SaveChangesAsync();

                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<UserRole>> Update(Guid? id, [FromBody] CreateUserRoleData userRoleData)
        {
            if (id is null)
            {
                return ValidationProblem("The provided id is not compatible.");
            }

            var command = new UpdateUserRoleCommand(_dbContext);

            try
            {
                var updatedUserRole = await command.Update(id.Value, userRoleData);

                var updateModelCommand = new UpdateUserRoleModelCommand();
                updateModelCommand.Update(_dbContext, updatedUserRole);

                await _dbContext.SaveChangesAsync();

                return Ok(updatedUserRole);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id is null)
            {
                return ValidationProblem("The provided id is not compatible.");
            }

            try
            {
                var userRoleToDelete = _dbContext.Roles.First(userRole => userRole.Id == id.Value);

                if (userRoleToDelete is null)
                {
                    return NotFound("No user role found with such id.");
                }

                _dbContext.Roles.Remove(userRoleToDelete);
                await _dbContext.SaveChangesAsync();

                return Ok("User role removed.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
