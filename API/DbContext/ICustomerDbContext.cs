using Common;
using Microsoft.EntityFrameworkCore;

namespace API.DbContext;

public interface ICustomerDbContext
{
    DbSet<Customer>? Customers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}