
namespace api.Models;
public record Chalenge(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    string Title,
    string Description,
    Object Participants,
    DateTime CreatedAt
);
