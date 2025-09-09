namespace api.Repositories;

public class AccountRepository : IAccountRepository
{

    #region Mongodb
    private readonly IMongoCollection<AppUser> _collection;
    private readonly ITokenService _tokenService;

    // Dependency Injection
    public AccountRepository(IMongoClient client, IMongoDbSettings dbSettings, ITokenService tokenService)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");

        _tokenService = tokenService;
    }
    #endregion

    public async Task<LoggInDto?> RegisterAsync(AppUser userInput, CancellationToken cancellationToken)
    {
        AppUser user = await _collection.Find<AppUser>(doc =>
            doc.Email == userInput.Email).FirstOrDefaultAsync(cancellationToken);

        if (user is not null)
            return null;

        await _collection.InsertOneAsync(userInput, null, cancellationToken);

        string? token = _tokenService.CreateToken(userInput);

        return Mappers.ConvertAppUserToLoggedInDto(userInput, token);

        // return loggedInDto;

        // DTO => Data / Transfer / Object
        // return Mappers.ConvertAppUserToLoggedInDto(userInput);
    }

    public async Task<LoggInDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken)
    {
        AppUser user =
         await _collection.Find(doc => doc.Email == userInput.Email && doc.Password == userInput.Password)
         .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
            return null;

        string? token = _tokenService.CreateToken(user);

        return Mappers.ConvertAppUserToLoggedInDto(user, token);

        // LoggedInDto loggedInDto =
        //     Mappers.ConvertAppUserToLoggedInDto(user);

        // return loggedInDto;
    }

    public async Task<DeleteResult?> DeleteByIdAsync(string userId, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(doc => doc.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
        {
            return null;
        }

        return await _collection.DeleteOneAsync<AppUser>(doc => doc.Id == userId, cancellationToken);
    }
    
    public async Task<LoggInDto?> ReloadLoggedInUserAsync(string userId, string token, CancellationToken cancellationToken)
    {
        AppUser? appUser = await _collection.Find<AppUser>(doc => doc.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        return Mappers.ConvertAppUserToLoggedInDto(appUser, token);
    }

}