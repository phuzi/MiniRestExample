using DataUploader.Readers;
using DataUploader.Services;
using Microsoft.Extensions.Logging;

namespace DataUploader;

public class Application
{
    private readonly ICustomerCsvReader _customerCsvReader;
    private readonly ICustomerUploadService _customerUploadService;
    private readonly ILogger<Application> _logger;

    public Application(
        ICustomerCsvReader customerCsvReader,
        ICustomerUploadService customerUploadService,
        ILogger<Application> logger)
    {
        _customerCsvReader = customerCsvReader ?? throw new ArgumentNullException(nameof(customerCsvReader));
        _customerUploadService = customerUploadService ?? throw new ArgumentNullException(nameof(customerUploadService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task ExecuteAsync(string[] args, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("{appName} running.", nameof(Application));

        if (args.Length == 0)
        {
            _logger.LogError("No file specified");
        }

        var customers = _customerCsvReader.Load(args[0]);

        await foreach (var customer in customers)
        {
            await _customerUploadService.Upload(customer);
        }
    }
}