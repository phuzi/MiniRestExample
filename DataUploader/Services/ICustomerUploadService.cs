using Common;

namespace DataUploader.Services;

public interface ICustomerUploadService
{
    Task Upload(Customer customer);
}