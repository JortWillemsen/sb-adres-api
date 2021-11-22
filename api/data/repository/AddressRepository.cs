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
        public async Task<IEnumerable<AddressEntity>> GetAll()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<AddressEntity> Get(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<AddressEntity> Create(AddressEntity addressEntity)
        {
            _context.Addresses.Add(addressEntity);
            await _context.SaveChangesAsync();

            return addressEntity;
        }

        public async Task Update(AddressEntity addressEntity)
        {
            _context.Entry(addressEntity).State = EntityState.Modified;
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