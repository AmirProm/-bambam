namespace api.Interfaces;

public interface IUserRepository
{
    public Task<LoggInDto?> UpdateByIdAsync(string userId, AppUser userInput, CancellationToken cancellationToken);
}
