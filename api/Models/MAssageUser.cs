using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record MassageUser
(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    ObjectId UserId,
    string Content,
    string Media,
    bool IsHidden,
    DateTime CreatedSend
);
