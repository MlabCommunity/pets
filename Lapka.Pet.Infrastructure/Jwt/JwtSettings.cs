namespace Lapka.Pet.Infrastructure.Jwt;

public class JwtSettings
{
    public int ExpiryMins { get; set; }
    public string Issuer { get; set; }
    public string RsaPrivateKeyPath { get; set; }
    public string RsaPublicKeyPath { get; set; }
    public int RefreshExpiryMonths { get; set; }
    public TimeSpan ClockSkew { get; set; }
}