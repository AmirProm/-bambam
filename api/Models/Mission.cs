namespace api.Models;
public record Mission
(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    ObjectId UserId,
    string Task, //تسک های مربوط به هر شخص
    bool IsCompleted,
    DateTime CreatedAt   
);
