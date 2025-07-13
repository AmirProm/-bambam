namespace api.Controllers;

                            //PrimaryConstructor
public class UserController(IUserRepository userRepository) : BaseApiController
{
    [HttpPut("update/{userId}")]
    public async Task<ActionResult<LoggInDto>> UpdateById(string userId, AppUser userInput, CancellationToken cancellationToken)
    {
        LoggInDto? loggedInDto = await userRepository.UpdateByIdAsync(userId, userInput, cancellationToken);

        if (loggedInDto is null)
            return BadRequest("Operation failed.");

        return loggedInDto;
    }   
}
