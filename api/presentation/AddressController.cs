using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBAddressAPI.data;
using SBAddressAPI.domain;

namespace SBAddressAPI.presentation
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            this._addressRepository = addressRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<AddressEntity>> GetAllAddresses()
        {
            return await _addressRepository.GetAll();
        }
    }
}