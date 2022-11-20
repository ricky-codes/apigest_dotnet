namespace ApiGest.Infrastructure.Authentication;

using ApiGest.Application.Common.Interfaces.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ApiGest.Application.Common.Interfaces.Services;
using ApiGest.Domain.Entities;

public class JwtTokenGenerator : IJwtTokenGenerator{
    

    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(User user){

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key")), 
            SecurityAlgorithms.HmacSha256);

        var claims = new [] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Firstname),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.Lastname),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: "ApiGest",
            expires: _dateTimeProvider.UtcNow.AddMinutes(60),
            claims: claims, 
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}