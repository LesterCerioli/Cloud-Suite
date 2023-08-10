namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface WidgetRepository
    {
         
         Task<Widget> GetByName(string Name);

         Task<Widget> GetByViewComponentName(string ViewComponentName);

         Task<Widget> GetByCreateUrl(string CreateUrl);

         Task<Widget> GetByEditUrl(string EditUrl);

         Task<Widget> GetByCreatedOn(DateTimeOffset CreatedOn);

         Task<IEnumerable<Widget>> GetAll();

         Task Add(Widget Widget);

         void Update(Widget Widget);

         void Remove(Widget Widget);


    }
}