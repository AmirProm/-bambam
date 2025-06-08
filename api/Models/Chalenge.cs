namespace api.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public record Chalenge(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    string Title,
    string Description,
    Object Participants,
    DateTime CreatedAt
);
