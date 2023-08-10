namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface VendorRepository
    {
         
         Task<Vendor> GetByName(string Name);

         Task<Vendor> GetBySlug(string Slug);

         Task<Vendor> GetByDescription(string Description);

         Task<Vendor> GetByEmail(string Email);

         Task<Vendor> GetByCreatedOn(DateTimeOffset CreatedOn);

         Task<Vendor> GetByLatestUpdatedOn(DateTimeOffset LatestUpdatedOn);

         Task<IEnumerable<Vendor>> GetAll();

         Task Add(Vendor Vendor);

         void Update(Vendor Vendor);

         void Remove(Vendor Vendor);

         
    }
}