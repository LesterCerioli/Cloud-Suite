namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface WidgetZoneRepository
    {
         
         Task<WidgetZone> GetByName(string Name);

         Task<WidgetZone> GetByDescription(string Description);

         Task<IEnumerable<WidgetZone>> GetAll();

         Task Add(WidgetZone WidgetZone);

         void Update(WidgetZone WidgetZone);

         void Remove(WidgetZone WidgetZone);


    }
}