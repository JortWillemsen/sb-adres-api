using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SBAddressAPI.Models
{
    public class Address
    {
        public Address() {}

        public Address(int id, string? street, int homeNumber, string? postalCode, string? city, string? country)
        {
            Id = id;
            Street = street;
            HomeNumber = homeNumber;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        [Key] public int Id { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}