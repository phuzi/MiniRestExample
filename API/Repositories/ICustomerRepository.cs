using Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Repositories;

public interface ICustomerRepository
{
    Task<int> AddAsync(Customer customer, CancellationToken cancellationToken);

    ValueTask<Customer?> GetAsync(Guid customerRef, CancellationToken cancellationToken);
}