namespace api.DTOs;

public static class Mappers
{
    public static LoggInDto ConvertAppUserToLoggedInDto(AppUser appUser, string tokenValue)
    {

        return new(
            Email: appUser.Email,
            Name: appUser.Name,
            Token: tokenValue
        );
    }

    public static LoginDto ConvertAppUserToLoginDto(AppUser appUser, string tokenValue)
    {
        // LoggedInDto loggedInDto = new(
        //     Email: appUser.Email,
        //     UserName: appUser.UserName,
        //     Age: appUser.Age
        // );

        // return loggedInDto;

        return new(
            Email: appUser.Email,
            Password: appUser.Password,
            Token: tokenValue
        );
    }

}