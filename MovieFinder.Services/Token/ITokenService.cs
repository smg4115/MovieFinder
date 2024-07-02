namespace MovieFinder.Services.Token;

public interface ITokenService
{
    Task<TokenResponse?> GetTokenAsync(TokenRequest model);
}
