using System.Collections.Generic;
using System.Threading.Tasks;
using SBAddressAPI.domain;

namespace SBAddressAPI.data
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> Get();
        Task<Address> Get(int id);
        Task<Address> Create(Address address);
        Task Update(Address address);
        Task Delete(int id);
    }
}