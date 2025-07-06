namespace Application.Model.Jwt;
public class IdentitySettings
{
    public string SecretKey { get; } = "sz8eI7OdHBrjrIo8j9nTW/rQyO1OvY0pAQ2wDKQZw/0=";
    public string Encryptkey { get; } = "1234567890123456";
    public string Issuer { get; } = "BaseApiIssuer";
    public string Audience { get; } = "BaseApiUser";
    public int ExpirationMinutes { get; set; } = 6;
    public int NotBeforeMinutes { get; set; } = 3;
}
