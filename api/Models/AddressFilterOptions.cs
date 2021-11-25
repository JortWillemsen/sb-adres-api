using System.Text;

namespace SBAddressAPI.Models
{
    public class AddressFilterOptions
    {
        public string Street { get; set; } = "";
        public int HomeNumber { get; set; }
        public string PostalCode { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";

        /// <summary>
        /// Creates a string to be used by Gridify for filtering.
        /// </summary>
        /// <returns>Gridify string for filtering</returns>
        public string ToGridifyString()
        {
            var builder = new StringBuilder();
            
            // Loop through the attributes of AddressFilterOptions.
            foreach (var property in typeof(AddressFilterOptions).GetProperties())
            {
                // Check if there isn't something in the attribute's value.
                if (property.GetValue(this) == null || property.GetValue(this)?.ToString() == "" ||
                    property.GetValue(this)?.ToString() == "0")
                {
                    // If there is nothing in the attribute we skip this attribute.
                    continue;
                }

                // Add the attribute to the string.
                builder.Append($"{property.Name} = {property.GetValue(this)}, ");
            }

            // At the end we need to remove the last ", " characters.
            if (builder.Length > 0)
                builder.Remove(builder.Length - 2, 2);

            return builder.ToString();
        }
    }
}