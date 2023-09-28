namespace DataUploader.Configuration;

public class CustomerApiSettings
{
    public string ClientId { get; set; } = string.Empty;

    public string ClientSecret { get; set; } = string.Empty;

    public string BaseUrl { get; set; } = string.Empty;

    public string AuthenticationEndpoint { get; set; } = string.Empty;

    public string CustomerEndpoint { get; set; } = string.Empty;
}