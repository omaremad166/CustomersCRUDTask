namespace CustomersCRUDTask.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public static List<Address> AdressesHandler(string addressesLinesString, int customerId)
        {
            string[] addressesLines = addressesLinesString.Split(',');
            List<Address> addresses = new List<Address>();
            foreach (string item in addressesLines)
            {
                Address address = new();
                address.AddressLine = item;
                address.CustomerId = customerId;
                addresses.Add(address);
            }
            return addresses;
        }
    }
}
