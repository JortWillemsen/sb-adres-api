using Microsoft.EntityFrameworkCore;
using SBAddressAPI.domain;

namespace SBAddressAPI.data
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options)
            :base(options)
        {
            Database.EnsureCreated();
            
        }
        public DbSet<AddressEntity> Addresses { get; set; } 
    }
}
