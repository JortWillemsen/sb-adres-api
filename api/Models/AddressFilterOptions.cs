using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.VisualBasic;

namespace SBAddressAPI.Models
{
    public class AddressFilterOptions
    {
        public string Street { get; set; } = "";
        public int HomeNumber { get; set; }
        public string PostalCode { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";

        public string ToGridifyString()
        {
            var builder = new StringBuilder();
            foreach (var property in typeof(AddressFilterOptions).GetProperties())
            {
                var value = property.GetValue(this);
                if (property.GetValue(this) == null || property.GetValue(this)?.ToString() == "" || property.GetValue(this)?.ToString() == "0")
                {
                    continue;
                }
                
                builder.Append($"{property.Name} = {property.GetValue(this)}, ");
            }

            if (builder.Length > 0)
                builder.Remove(builder.Length - 2, 2);

            return builder.ToString();
        }
    }
}