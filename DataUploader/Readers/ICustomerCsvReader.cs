using Common;

namespace DataUploader.Readers;

public interface ICustomerCsvReader
{
    IAsyncEnumerable<Customer> Load(string filename);
}