using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SBAddressAPI.Models
{
    public class AddressFilterOptions
    {
        public string Street { get; set; } = "";
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
    }
}