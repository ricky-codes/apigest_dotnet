namespace ApiGest.Application.Common.Interfaces.Authentication;

using ApiGest.Domain.Entities;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}