using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Gridify;
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

        public Task<List<Address>> GetAll(AddressSortOptions sortOptions, AddressFilterOptions options)
        {
            var gq = new GridifyQuery {Filter = options.ToGridifyString(), OrderBy = sortOptions.SortBy};
            return _context.Addresses.ApplyFilteringAndOrdering(gq).ToListAsync();
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