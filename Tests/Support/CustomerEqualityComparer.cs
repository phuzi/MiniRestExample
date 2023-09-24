using Common;

namespace Tests.Support;

public class CustomerEqualityComparer : IEqualityComparer<Customer>
{
    public bool Equals(Customer? x, Customer? y)
    {
        if (x is null || y is null)
            return false;

        return x == y
               || (
                   x.CustomerRef == y.CustomerRef
                   && x.CustomerName == y.CustomerName
                   && x.AddressLine1 == y.AddressLine1
                   && x.AddressLine2 == y.AddressLine2
                   && x.Town == y.Town
                   && x.County == y.County
                   && x.Country == y.Country
                   && x.Postcode == y.Postcode
               );
    }

    public int GetHashCode(Customer obj)
    {
        return obj.GetHashCode();
    }
}
