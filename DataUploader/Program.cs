using DataUploader;
using DataUploader.Readers;
using DataUploader.Services;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using DataUploader.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddHttpClient("CustomerApi", client =>
    {
        client.BaseAddress = new Uri(builder.Configuration["CustomerApi:BaseUrl"]!);
    })
    .AddPolicyHandler(GetRetryPolicy());

builder.Services.AddTransient<Application>();
builder.Services.AddTransient<ICustomerCsvReader, CustomerCsvReader>();
builder.Services.AddTransient<ICustomerUploadService, CustomerUploadService>();

builder.Services.Configure<CustomerApiSettings>(builder.Configuration.GetSection("CustomerApi"));

using var host = builder.Build();

// Resolve all dependencies
var app = host.Services.GetRequiredService<Application>();

// Run the app passing command line arguments.
await app.ExecuteAsync(args);


static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}