using Common;
using Microsoft.Extensions.Logging;

namespace DataUploader.Services;

public interface ICustomerUploadService
{
    Task Upload(Customer customer);
}

public class CustomerUploadService : ICustomerUploadService
{
    private readonly ILogger<CustomerUploadService> _logger;

    public CustomerUploadService(ILogger<CustomerUploadService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task Upload(Customer customer)
    {
        throw new NotImplementedException();
    }
}