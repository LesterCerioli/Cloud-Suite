namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface AddressRepository
    {

        Task<Address> GetByContactname(string ContactName);

        Task<Address> GetByAddressLine1(string AddressLine1);

        Task<IEnumerable<Address>> GetAll();

        Task Add(Address address);

        void Update(Address address);

        void Remove(Address address);
         
    }
}