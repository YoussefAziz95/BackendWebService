namespace Application.Model.Jwt;
public class IdentitySettings
{
    public required string SecretKey { get; set; } = "sz8eI7OdHBrjrIo8j9nTW/rQyO1OvY0pAQ2wDKQZw/0=";
    public required string Encryptkey { get; set; } = "1234567890123456";
    public required string Issuer { get; set; } = "BaseApiIssuer";
    public required string Audience { get; set; } = "BaseApiUser";
    public int ExpirationMinutes { get; set; } = 6;
    public int NotBeforeMinutes { get; set; } = 3;
}
