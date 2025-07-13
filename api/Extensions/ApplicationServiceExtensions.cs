namespace api.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        #region MongoDbSettings
        ///// get values from this file: appsettings.Development.json /////
        // get section
        services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));

        // get values
        services.AddSingleton<IMongoDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

        // get connectionString to the dbTest.ShowName();

        services.AddSingleton<IMongoClient>(serviceProvider =>
        {
            MongoDbSettings uri = serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;

            return new MongoClient(uri.ConnectionString);
        });
        #endregion MongoDbSettings

        #region Cors: baraye ta'eede Angular HttpClient requests
        services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            });
        #endregion Cors

        return services;
    }
}
