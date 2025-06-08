using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record Mission
(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    ObjectId UserId,
    string Task,
    bool IsCompleted,
    DateTime CreatedAt
);
