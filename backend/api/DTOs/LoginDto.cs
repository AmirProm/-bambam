namespace api.DTOs;

public record LoginDto (
    [EmailAddress]
    string Email,
    string Password
);
