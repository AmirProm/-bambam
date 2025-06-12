using api.DTOs;
using api.Models;
using MongoDB.Driver;

namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<Loggind?> RegisterAsync(AppUser userInput, CancellationToken cancellationToken);
    public Task<Loggind?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken);

    // public Task<AppUser?> UpdataAsync(string userId, CancellationToken cancellationToken);
    
    public Task<DeleteResult?> DeleteByIdAsync(string userId, CancellationToken cancellationToken);
}
