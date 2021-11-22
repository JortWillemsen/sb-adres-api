using System.Collections.Generic;
using System.Threading.Tasks;
using SBAddressAPI.Models;

namespace SBAddressAPI.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAll();
        Task<Address?> Get(int id);
        Task<Address> Create(Address address);
        Task Update(Address address);
        Task Delete(int id);
    }
}