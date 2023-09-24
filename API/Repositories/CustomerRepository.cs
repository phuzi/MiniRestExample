using API.DbContext;
using Common;

namespace API.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ICustomerDbContext _context;

    public CustomerRepository(ICustomerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<int> AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        await _context.Customers!.AddAsync(customer, cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask<Customer?> GetAsync(Guid customerRef, CancellationToken cancellationToken)
    {
        return await _context.Customers!.FindAsync(new object[] { customerRef }, cancellationToken: cancellationToken);
    }
}