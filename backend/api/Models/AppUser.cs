using System.Runtime.InteropServices;

namespace api.Models;

public record AppUser(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    // string IdentifierHash,
    [EmailAddress] string Email,
    string UserName,
    string Password,
    string ConfirmPassword,
    [Range(typeof(DateOnly), "1900-01-01", "2050-01-01", ErrorMessage = "Date of birth must be between 1900 and 2050.")]
    DateOnly DateOfBirth,
    DateTime LastActive,
    string Gender,
    string City,
    string Country,
    List<Photo> Photos
);

// DTO => Data/Transfer/Object
// public record LoggedInUserDto(
//     string Email,
//     string Name
// );