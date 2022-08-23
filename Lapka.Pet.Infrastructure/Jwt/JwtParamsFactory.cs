using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Lapka.Pet.Infrastructure.Jwt;

public static class JwtParamsFactory
{
    public static SigningCredentials CreateSigningCredentials(JwtSettings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.RsaPrivateKeyPath))
        {
            throw new Exception("no private key!");
        }

        var privateRsa = RSA.Create();
        var privateKey = File.ReadAllText(settings.RsaPrivateKeyPath);
        privateRsa.ImportFromPem(privateKey);
        var privateKey2 = new RsaSecurityKey(privateRsa);
        return new SigningCredentials(privateKey2, SecurityAlgorithms.RsaSha256);
    }

    public static TokenValidationParameters CreateParameters(JwtSettings settings)
    {
        var publicRsa = RSA.Create();
        var publicKey = File.ReadAllText(settings.RsaPublicKeyPath);
        publicRsa.ImportFromPem(publicKey);
        var issuerSigningKey = new RsaSecurityKey(publicRsa);

        return new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidIssuer = settings.Issuer,
            IssuerSigningKey = issuerSigningKey,
            ClockSkew = settings.ClockSkew
        };
    }
}