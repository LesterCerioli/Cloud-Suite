namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface CustomerGroupUserRepository
    {

         Task<CustomerGroupUser> GetByUserId(Long UserId);

         Task<CustomerGroupUser> GetByUser(User User);

         Task<CustomerGroupUser> GetByCustomerGroupId(Long CustomerGroupId);

         Task<CustomerGroupUser> GetByCustomerGroup (CustomerGroup CustomerGroup);

         Task<CustomerGroupUser> GetByName(Name Name);
        
         Task<CustomerGroupUser> GetByCpf(Cpf Cpf);
         
         Task<IEnumerable<CustomerGroupUser>> GetAll();

         Task Add(CustomerGroupUser CustomerGroupUser);

         void Update(CustomerGroupUser CustomerGroupUser);

         void Remove(CustomerGroupUser CustomerGroupUser);


    }
}