namespace api.Models;
public record AppUser
(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    [EmailAddress] string Email,
    [Length(2, 22)] string Name,
    [Length(8, 22)] string Password,
    [Length(8, 22)] string ConfirmPassword,
     int Age,
     Contactinfo Contactinfo
);
