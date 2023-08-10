namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface WidgetInstanceRepository
    {
         
         Task<WidgetInstance> GetByName(string Name);

         Task<WidgetInstance> GetByCreatedOn(DateTimeOffset CreatedOn);

         Task<WidgetInstance> GetByLatestUpdatedOn(DateTimeOffset LatestUpdatedOn);

         Task<WidgetInstance> GetByPublishStart(DateTimeOffset? PublishStart);

         Task<WidgetInstance> GetByPublishEnd(DateTimeOffset PublishEnd);

         Task<WidgetInstance> GetByWidgetId(string WidgetId);

         Task<WidgetInstance> GetByWidget(Widget Widget);

         Task<WidgetInstance> GetByWidgetZoneId(long WidgetZoneId );

         Task<WidgetInstance> GetByWidgetZone(WidgetZone WidgetZone);

         Task<WidgetInstance> GetByDisplayOrder(int DisplayOrder);

         Task<WidgetInstance> GetByData(string Data);

         Task<WidgetInstance> GetByHtmlData(string HtmlData);

         Task<IEnumerable<WidgetInstance>> GetAll();

         Task Add(WidgetInstance WidgetInstance);

         void Update(WidgetInstance WidgetInstance);

         void Remove(WidgetInstance WidgetInstance);
         

    }
}