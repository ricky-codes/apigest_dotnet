namespace ApiGest.Infrastructure.Authentication;

public class JwtSettings{
    public const String SectionName = "JwtSettings";
    public string Secret { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
}