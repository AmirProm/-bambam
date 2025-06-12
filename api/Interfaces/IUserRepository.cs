using api.Models;
using api.DTOs;

namespace api.Interfaces;

public interface IUserRepository
{
    public Task<Loggind?> UpdateByIdAsync(string userId, AppUser userInput, CancellationToken cancellationToken);
}
