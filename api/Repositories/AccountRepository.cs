using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Settings;
using MongoDB.Driver;

namespace api.Repositories;

public class AccountRepository : IAccountRepository
{

    private readonly IMongoCollection<AppUser> _collection;

    // Dependency Injection
    public AccountRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");
    }
    public async Task<Loggind?> RegisterAsync(AppUser userInput, CancellationToken cancellationToken)
    {
        AppUser user = await _collection.Find<AppUser>(doc =>
            doc.Email == userInput.Email).FirstOrDefaultAsync(cancellationToken);

        if (user is not null)
            return null;

        await _collection.InsertOneAsync(userInput, null, cancellationToken);

        Loggind loggedInDto = new(
            Email: userInput.Email,
            Name: userInput.Name
        );

        return loggedInDto;
    }

    public async Task<Loggind?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken)
    {

        AppUser user = await _collection.Find(doc => doc.Email == userInput.Email &&
        doc.Password == userInput.Password).FirstOrDefaultAsync(cancellationToken);

        if (user is null)
            return null;

        Loggind loggind = new(
        Email: user.Email,
        Name: user.Name);

        return loggind;
    }

    public async Task<DeleteResult?> DeleteByIdAsync(string userId, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(doc => doc.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;
        
        return await _collection.DeleteOneAsync<AppUser>(doc => doc.Id == userId, cancellationToken);
    }
}
