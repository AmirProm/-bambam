namespace api.Models;
public record MassageRoom
(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    ObjectId RoomId,
    ObjectId UserId,
    string Content,
    string Media,
    bool IsHidden,
    DateTime CreatedSend
);
