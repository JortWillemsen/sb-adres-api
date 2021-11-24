using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBAddressAPI.Models;
using SBAddressAPI.Repositories;

namespace SBAddressAPI.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public List<Address> GetAllAddresses([FromQuery] AddressSortOptions sortOptions, [FromQuery] AddressFilterOptions filterOptions)
        {
            var result = _addressRepository.GetAll(sortOptions, filterOptions);

            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Address>> GetAddressById(int id)
        {
            var address = await _addressRepository.Get(id);
            if (address == null)
                return NotFound();

            return address;
        }


        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress([FromBody] CreateAddressDto dto)
        {
            var newAddress = await _addressRepository.Create(
                new Address(0, dto.Street, dto.HomeNumber, dto.PostalCode, dto.City, dto.Country));

            return CreatedAtAction(nameof(GetAddressById), new {id = newAddress.Id}, newAddress);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditAddress(int id, [FromBody] UpdateAddressDto dto)
        {
            if (await _addressRepository.Get(id) == null)
                return NotFound();

            await _addressRepository.Update(
                new Address(id, dto.Street, dto.HomeNumber, dto.PostalCode, dto.City, dto.Country));

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            if (await _addressRepository.Get(id) == null)
                return NotFound();

            await _addressRepository.Delete(id);
            return NoContent();
        }
    }
}