namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface EntityRepository
    {
         
         Task<Entity> GetBySlug(string Slug);

         Task<Entity> GetByName(string Name);

         Task<Entity> GetByEntityTypeId(string EntityTypeId);

         Task<IEnumerable<Entity>> GetAll();

         Task Add(Entity Entity);

         void Update(Entity Entity);

         void Remove(Entity Entity);
         
    }
}