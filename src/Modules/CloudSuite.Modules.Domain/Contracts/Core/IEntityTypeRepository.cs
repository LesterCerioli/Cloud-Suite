namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface EntityType
    {
         
         Task<EntityType> GetByName(string Name);

         Task<EntityType> GetByAreaName(string AreaName);

         Task<EntityType> GetByRoutingController(string RoutingController);

         Task<EntityType> GetByRoutingAction(string RoutingController);

         Task<IEnumerable<EntityType>> GetAll();

         Task Add(EntityType EntityType);

         void Update(EntityType EntityType);

         void Remove(EntityType EntityType);


    }
}