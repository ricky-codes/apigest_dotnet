namespace ApiGest.Application.Services.Authentication;

public interface IAuthService{
    AuthResult Login(string email, string password);
    AuthResult Register(string firstname, string lastname, string email, string password);
}