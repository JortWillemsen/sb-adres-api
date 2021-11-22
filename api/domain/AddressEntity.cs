using System.ComponentModel.DataAnnotations;

namespace SBAddressAPI.domain
{
    public class AddressEntity
    {
        public AddressEntity() {}
        
        [Key] public int Id { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}