namespace ApiGest.Application.Services.Authentication;

public class AuthService : IAuthService
{
    public AuthResult Login(string email, string password)
    {
        return new AuthResult(Guid.NewGuid(), "firstname", "lastname", email, "token");
    }

    public AuthResult Register(string firstname, string lastname, string email, string password)
    {
        return new AuthResult(Guid.NewGuid(), firstname, lastname, email, "token");
    }
}