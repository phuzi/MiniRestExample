using System.IdentityModel.Tokens.Jwt;
using System.Text;
using API.Configuration;
using API.Services;
using Azure.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Moq;
using TechTalk.SpecFlow.Assist;

namespace Tests.StepDefinitions
{
    [Binding]
    public sealed class AuthenticationStepDefinitions
    {
        private ClientAuthenticationService? _authService;
        private ApiCredentials? _credentials;
        private Mock<IOptions<ApiCredentials>>? _credentialOptions;
        private Mock<IOptions<JwtConfiguration>>? _configurationOptions;
        private Exception? _exception;
        private JwtConfiguration? _jwtConfiguration;
        private string? _token;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _jwtConfiguration = new JwtConfiguration
            {
                // ReSharper disable once StringLiteralTypo
                Key = "l;kjhsdfjkoahsdgjkoh",
            };

            _configurationOptions = new Mock<IOptions<JwtConfiguration>>();
            _configurationOptions.SetupGet(x => x.Value).Returns(_jwtConfiguration ?? new JwtConfiguration());

            _credentials = new ApiCredentials();
            _credentialOptions = new Mock<IOptions<ApiCredentials>>();
            _credentialOptions.SetupGet(x => x.Value).Returns(_credentials ?? new ApiCredentials());


            _authService = new ClientAuthenticationService(_configurationOptions!.Object, _credentialOptions.Object);
        }

        [Given("The following credentials are configured:")]
        public void GivenTheFollowingCredentialsAreConfigured(Table table)
        {
            var configuration = table.CreateInstance<ApiCredentials>();
            _credentials!.ClientId = configuration.ClientId;
            _credentials!.ClientSecret = configuration.ClientSecret;
        }

        [Given("The token lifetime is configured to be (.*) minutes")]
        public void GivenTheTokenLifetimeIsConfiguredToBeMinutes(int lifetime)
        {
            _jwtConfiguration!.Lifetime = lifetime;
        }

        [Given(@"Token audience is configured to be ""([^""]*)""")]
        public void GivenTokenAudienceIsConfiguredToBe(string audience)
        {
            _jwtConfiguration!.Audience = audience;
        }

        [Given(@"Token issuer is configured to be ""([^""]*)""")]
        public void GivenTokenIssuerIsConfiguredToBe(string issuer)
        {
            _jwtConfiguration!.Issuer = issuer;
        }

        [When(@"The client Id ""([^""]*)"" and client secret ""([^""]*)"" are used to authenticate")]
        public void WhenTheClientIdAndClientSecretAreUsedToAuthenticate(string clientId, string clientSecret)
        {
            try
            {
                _token = _authService!.Authenticate(clientId, clientSecret);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Given(@"Token signing key is configured to be ""([^""]*)""")]
        public void GivenTokenSigningKeyIsConfiguredToBe(string signingKey)
        {
            _jwtConfiguration!.Key = signingKey;
        }

        [Then("A bearer token should be returned")]
        public void ThenABearerTokenShouldBeReturned()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_token));
        }

        [Then("A JWT bearer token should be returned")]
        public void ThenAJwtBearerTokenShouldBeReturned()
        {
            try
            {
                _ = new JwtSecurityToken(_token);
            }
            catch
            {
                Assert.Fail("Token was not a valid JWT");
            }
        }

        [Then("An AuthenticationFailedException should be thrown")]
        public void ThenAnAuthenticationFailedExceptionShouldBeThrown()
        {
            Assert.IsInstanceOfType(_exception, typeof(AuthenticationFailedException));
        }

        [Then(@"The token audience should be ""([^""]*)""")]
        public void ThenTheTokenAudienceShouldBe(string audience)
        {
            var jwt = new JwtSecurityToken(_token);

            Assert.IsTrue(jwt.Audiences.Contains(audience));
        }

        [Then(@"The token issuer should be ""([^""]*)""")]
        public void ThenTheTokenIssuerShouldBe(string issuer)
        {
            var jwt = new JwtSecurityToken(_token);

            Assert.AreEqual(issuer, jwt.Issuer);
        }

        [Then("The token should be valid for (.*) minutes")]
        public void ThenTheTokenShouldBeValidForMinutes(int lifetime)
        {
            var jwt = new JwtSecurityToken(_token);

            var timeSpan = jwt.ValidTo.Subtract(DateTime.UtcNow);

            Assert.AreEqual(lifetime, Math.Ceiling(timeSpan.TotalMinutes));
        }

        [Then(@"The token should be signed with ""([^""]*)""")]
        public void ThenTheTokenShouldBeSignedWith(string signingKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
            };

            try
            {
                tokenHandler.ValidateToken(_token, validationParameters, out _);
            }
            catch (SecurityTokenInvalidSigningKeyException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"The token subject should be ""([^""]*)""")]
        public void ThenTheTokenSubjectShouldBe(string subject)
        {
            var jwt = new JwtSecurityToken(_token);

            Assert.AreEqual(subject, jwt.Subject);
        }

    }
}