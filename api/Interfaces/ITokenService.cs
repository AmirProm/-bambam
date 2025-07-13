namespace api.Interfaces;

public interface ITokenService
{
    public string CreateToken(AppUser appUser);
}