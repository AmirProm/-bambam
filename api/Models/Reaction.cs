using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record Reaction
(

    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    ObjectId StoryId,
    ObjectId UserId,
    string Type,
    DateTime CreatedAt
);
