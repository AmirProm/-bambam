using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record Story
(
[property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    [Length(24, 24)] string UserId,
    string Content, // محتوا استوری
    string Media,
    DateTime CreatedStory,
    DateTime ExpiresStory
);
