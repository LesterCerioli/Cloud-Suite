namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface CustomerRepository
    {

         Task<Customer> GetByName(Name Name);

         Task<IEnumerable<Customer>> GetAll();

         Task Add(Customer customer);

        void Update(Customer customer);

        void Remove(Customer customer);
        
    }
}