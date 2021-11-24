using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SBAddressAPI.Models;

namespace SBAddressAPI.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _context;

        public AddressRepository(AddressContext context)
        {
            _context = context;
        }

        public List<Address> GetAll(AddressSortOptions sortOptions, AddressFilterOptions options)
        {
            var all = _context.Addresses.ToList();
            var filtered = new List<Address>();
            foreach (var address in all)
            {
                if (options.Street != "")
                {
                    if (address.Street != options.Street)
                    {
                        continue;
                    }
                }
                
                if (options.HouseNumber != 0)
                {
                    if (address.HomeNumber != options.HouseNumber)
                    {
                        continue;
                    }
                }
                if (options.PostalCode != "")
                {
                    if (address.PostalCode != options.PostalCode)
                    {
                        continue;
                    }
                }
                
                if (options.City != "")
                {
                    if (address.City != options.City)
                    {
                        continue;
                    }
                }
                
                if (options.Country != "")
                {
                    if (address.Country != options.Country)
                    {
                        continue;
                    }
                }

                filtered.Add(address);

            }

            // var sorted = SortAddresses(filtered.AsQueryable(), sortOptions);
            // return sorted;

            return filtered;
        }

        private List<Address> SortAddresses(IQueryable<Address> unSorted, AddressSortOptions sortOptions)
        {
            var property = sortOptions.SortBy.Split(" ")[0];
            var order = sortOptions.SortBy.Split(" ")[1] == "asc" ? "ascending" : "descending";

            var propertyInfos = typeof(Address).GetProperties();
            var objectProperty = propertyInfos.FirstOrDefault(
                pi => pi.Name.Equals(property, StringComparison.InvariantCultureIgnoreCase));
            if (objectProperty == null)
            {
                return unSorted.ToList();
            }
            
            var query = $"${objectProperty.Name} ${order}";

            return unSorted.OrderBy(query).ToList();
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address?> Get(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<Address> Create(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task Update(Address address)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null) _context.Addresses.Remove(address);

            await _context.SaveChangesAsync();
        }
    }
}