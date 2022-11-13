namespace ApiGest.Infrastructure.Authentication;

using ApiGest.Application.Common.Interfaces.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using ApiGest.Application.Common.Interfaces.Services;

public class JwtTokenGenerator : IJwtTokenGenerator{
    

    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;


    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions){
        this._dateTimeProvider = dateTimeProvider;
        this._jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(Guid userId, string firstname, string lastname){

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this._jwtSettings.Secret)), 
            SecurityAlgorithms.HmacSha256);

        var claims = new [] {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstname),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: this._jwtSettings.Issuer,
            audience: this._jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(this._jwtSettings.ExpiryMinutes),
            claims: claims, 
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}