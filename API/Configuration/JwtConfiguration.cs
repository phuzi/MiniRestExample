namespace API.Configuration;

public class JwtConfiguration
{
    public int Lifetime { get; set; } = 60;
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? Key { get; set; }
}