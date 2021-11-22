namespace SBAddressAPI.domain
{
    public class Address
    {
        public Address(int id, string street, int homeNumber, string postalCode, string city, string country)
        {
            Id = id;
            Street = street;
            HomeNumber = homeNumber;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        private int Id { get; set; }
        private string Street { get; set; }
        private int HomeNumber { get; set; }
        private string PostalCode { get; set; }
        private string City { get; set; }
        private string Country { get; set; }
    }
}