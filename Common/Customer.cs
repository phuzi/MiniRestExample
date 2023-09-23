namespace Common
{
    public class Customer
    {
        public Guid CustomerRef { get; set; } = Guid.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public string AddressLine1 { get; set; } = string.Empty;
     
        public string AddressLine2 { get; set; } = string.Empty;

        public string Town { get; set; } = string.Empty;
        
        public string County { get; set; } = string.Empty;
        
        public string Country { get; set; } = string.Empty;
        
        public string Postcode { get; set; } = string.Empty;
    }
}