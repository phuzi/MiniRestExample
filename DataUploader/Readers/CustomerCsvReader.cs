using Common;
using Microsoft.Extensions.Logging;

namespace DataUploader.Readers;

public class CustomerCsvReader : ICustomerCsvReader
{
    private readonly ILogger<CustomerCsvReader> _logger;

    public CustomerCsvReader(ILogger<CustomerCsvReader> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IAsyncEnumerable<Customer> Load(string filename)
    {
        throw new NotImplementedException();
    }
}

public interface ICustomerCsvReader
{
    IAsyncEnumerable<Customer> Load(string filename);
}