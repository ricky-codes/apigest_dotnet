namespace ApiGest.Application.Services.Authentication;

using ApiGest.Application.Common.Interfaces.Authentication;


public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(IJwtTokenGenerator jwtTokenGenerator){
        this._jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthResult Login(string email, string password)
    {
        return new AuthResult(Guid.NewGuid(), "firstname", "lastname", email, "token");
    }

    public AuthResult Register(string firstname, string lastname, string email, string password)
    {
        // Check if user already exists

        // Create user (generate unique Id)

        // Create JWT token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstname, lastname);

        return new AuthResult(userId, firstname, lastname, email, token);
    }
}