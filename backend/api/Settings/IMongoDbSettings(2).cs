namespace api.Settings;
public interface IMongoDbSettings
{
    string? ConnectionString { get; init; }
    string? DatabaseName { get; init; }
}