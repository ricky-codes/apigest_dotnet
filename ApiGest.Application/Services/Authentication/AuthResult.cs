namespace ApiGest.Application.Services.Authentication;

using ApiGest.Domain.Entities;
public record AuthResult(
    User user,
    string Token
);
