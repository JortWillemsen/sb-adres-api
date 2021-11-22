using Microsoft.EntityFrameworkCore;

namespace SBAddressAPI.Models
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options)
            :base(options)
        {
            Database.EnsureCreated();
            
        }
        public DbSet<Address> Addresses { get; set; } 
    }
}
