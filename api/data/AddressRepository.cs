using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBAddressAPI.domain;

namespace SBAddressAPI.data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _context;

        public AddressRepository(AddressContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Address>> Get()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> Get(int id)
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