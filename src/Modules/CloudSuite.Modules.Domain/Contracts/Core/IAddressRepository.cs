using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface IAddressRepository
    {
        Task<Address> GetByCotactname(string contactName);

        Task<Address> GetByAddressLine1(string addressLine1);

        Task<IEnumerable<Address>> GetAll();

        Task Add(Address address);

        void Update(Address address);

        void Remove(Address address);
         
    }
}