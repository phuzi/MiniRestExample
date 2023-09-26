using DataUploader;
using DataUploader.Readers;
using DataUploader.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddTransient<Application>();
builder.Services.AddTransient<ICustomerCsvReader, CustomerCsvReader>();
builder.Services.AddTransient<ICustomerUploadService, CustomerUploadService>();

using var host = builder.Build();

// Resolve all dependencies
var app = host.Services.GetRequiredService<Application>();

// Run the app passing command line arguments.
await app.ExecuteAsync(args);
