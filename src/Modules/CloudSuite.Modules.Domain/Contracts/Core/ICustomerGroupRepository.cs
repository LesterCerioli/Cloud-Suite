namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface CustomerGroupRepository
    {
         
         Task<CustomerGroup> GetByName(Name Name);

         Task<CustomerGroup> GetByDescription(string Description);

         Task<CustomerGroup> GetByCreatedOn(DateTimeOffset CreatedOn);

         Task<CustomerGroup> GetByLatestUpdatedOn(DateTimeOffset LatestUpdatedOn);

         Task<IEnumerable<CustomerGroup>> GetAll();

         Task Add(CustomerGroup CustomerGroup);

         void Update(CustomerGroup CustomerGroup);

         void Remove(CustomerGroup CustomerGroup);
         
    }
}