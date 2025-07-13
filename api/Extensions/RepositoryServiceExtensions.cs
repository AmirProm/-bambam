// using api.Services;

namespace api.Extensions;

public static class RepositoryServiceExtensions
{
    public static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        // services.AddScoped<ITokenService, TokenService>();


        return services;
    }
}
