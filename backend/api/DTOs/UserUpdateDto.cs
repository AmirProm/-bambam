namespace api.DTOs;

public record UserUpdateDto(
    [Length(2, 30)] string City,
    [Length(2, 30)] string Country
);