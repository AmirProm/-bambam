namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<LoggInDto?> RegisterAsync(AppUser userInput, CancellationToken cancellationToken);
    public Task<LoggInDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken);
    public Task<DeleteResult?> DeleteByIdAsync(string userId, CancellationToken cancellationToken);
    public Task<LoggInDto?> ReloadLoggedInUserAsync(string userId, string token, CancellationToken cancellationToken);

}
