namespace SBAddressAPI.domain
{
    public class Address
    {
        public Address(string street, int homeNumber, string postalCode, string city, string country)
        {
            Street = street;
            HomeNumber = homeNumber;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        private string Street { get; set; }
        private int HomeNumber { get; set; }
        private string PostalCode { get; set; }
        private string City { get; set; }
        private string Country { get; set; }
    }
}