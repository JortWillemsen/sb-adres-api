using System.Collections.Generic;
using System.Threading.Tasks;
using SBAddressAPI.domain;

namespace SBAddressAPI.data
{
    public interface IAddressRepository
    {
        Task<IEnumerable<AddressEntity>> GetAll();
        Task<AddressEntity> Get(int id);
        Task<AddressEntity> Create(AddressEntity addressEntity);
        Task Update(AddressEntity addressEntity);
        Task Delete(int id);
    }
}