using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Security.Authentication;
using System.Web;
using Common;
using DataUploader.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataUploader.Services;

public class CustomerUploadService : ICustomerUploadService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<CustomerUploadService> _logger;
    private readonly CustomerApiSettings _apiSettings;

    public CustomerUploadService(IOptions<CustomerApiSettings> options, IHttpClientFactory httpClientFactory, ILogger<CustomerUploadService> logger)
    {
        _apiSettings = options?.Value ?? throw new ArgumentNullException(nameof(options));
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    private string? _bearerToken;

    private async Task<string?> GetBearerToken()
    {
        // Check if current token is set and is still valid
        if (_bearerToken != null && new JwtSecurityToken(_bearerToken).ValidTo >= DateTime.UtcNow)
        {
            return _bearerToken;
        }

        _logger.LogInformation("Authenticating with API");

        try
        {
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams.Add("clientId", _apiSettings.ClientId);
            queryParams.Add("clientSecret", _apiSettings.ClientSecret);

            var client = _httpClientFactory.CreateClient("CustomerApi");
            var response = await client.GetAsync($"{_apiSettings.AuthenticationEndpoint}?{queryParams}");

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var message =
                    $"Failed to authenticate with API - {response?.StatusCode.ToString() ?? "Response was null!"}\n{content}";

                _logger.LogError(message);
                throw new Exception(message);
            }

            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
            if (tokenResponse != null)
            {
                try
                {
                    _bearerToken = tokenResponse.Token;
                    _logger.LogInformation("Authentication successful");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Retrieved token was not valid - <{token}>", tokenResponse.Token);
                    throw;
                }
            }
        }
        catch (Exception ex)
        {
            throw new AuthenticationException("There was a problem trying to authenticate to the API.", ex);
        }

        if (_bearerToken == null)
        {
            throw new AuthenticationException("There was a problem trying to authenticate to the API.");
        }

        return _bearerToken;
    }

    public async Task Upload(Customer customer)
    {
        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_apiSettings.CustomerEndpoint, UriKind.Relative),
            Content = JsonContent.Create(customer, new MediaTypeHeaderValue(MediaTypeNames.Application.Json)),
        };

        var bearerToken = await GetBearerToken();
        if (bearerToken != null)
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
        }

        var client = _httpClientFactory.CreateClient("CustomerApi");
        var response = await client.SendAsync(requestMessage);

        response.EnsureSuccessStatusCode();
    }

    // ReSharper disable once ClassNeverInstantiated.Local
    private class TokenResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}