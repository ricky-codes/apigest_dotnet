namespace ApiGest.Application.Services.Authentication;

public record AuthResult(
    Guid Id,
    string Firstname,
    string Lastname,
    string Email,
    string Token
);
