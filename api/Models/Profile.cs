using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record Profile
(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    [Length(24, 24)] string UserId,
    string ROle,
    string Bio,
    string Skills,
    string Avatar,
    DateTime CreatedAt

);
