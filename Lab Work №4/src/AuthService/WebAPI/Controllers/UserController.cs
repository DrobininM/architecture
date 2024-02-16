using Application.Users.Commands;
using Application.Users.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Commands;
using Persistence.Mappers;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UsersDbContext _dbContext;

        public UserController(UsersDbContext dataAccessProvider)
        {
            _dbContext = dataAccessProvider;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var query = new GetAllUsersQuery(_dbContext);

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
        public async Task<ActionResult<User>> Get(Guid? id)
        {
            if (id is null)
            {
                return ValidationProblem("The provided id is not compatible.");
            }

            var query = new GetUserQuery(_dbContext);

            try
            {
                var queryResult = await query.Query(id.Value);

                if (queryResult is null)
                {
                    return NotFound("No user found with such id.");
                }

                return Ok(queryResult);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<User>> Create([FromBody] CreateUserData userData)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem("Didn't get these parameters to complete the request: " + String.Join(", ", ModelState.Keys));
            }

            var createCommand = new CreateUserCommand(_dbContext);

            try
            {
                var result = createCommand.Create(userData);

                await _dbContext.Users.AddAsync(UserMapper.MapToModel(result, _dbContext));
                await _dbContext.SaveChangesAsync();

                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<User>> Update(Guid? id, [FromBody] CreateUserData userData)
        {
            if (id is null)
            {
                return ValidationProblem("The provided id is not compatible.");
            }

            var command = new UpdateUserCommand(_dbContext, _dbContext);

            try
            {
                var updatedUser = await command.Update(id.Value, userData);

                var updateModelCommand = new UpdateUserModelCommand();
                updateModelCommand.Update(_dbContext, updatedUser);

                await _dbContext.SaveChangesAsync();

                return Ok(updatedUser);
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
                var userToDelete = _dbContext.Users.First(user => user.Id == id.Value);

                if (userToDelete is null)
                {
                    return NotFound("No user found with such id.");
                }

                _dbContext.Users.Remove(userToDelete);
                await _dbContext.SaveChangesAsync();

                return Ok("User removed.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
