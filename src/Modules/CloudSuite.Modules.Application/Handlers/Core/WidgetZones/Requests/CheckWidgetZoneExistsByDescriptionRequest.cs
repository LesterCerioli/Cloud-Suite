using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Requests
{
  public class CheckWidgetZoneExistsByDescriptionRequest : IRequest<CheckWidgetZoneExistsByDescriptionResponse>
  {
    public Guid Id { get; private set; }  
    public string? Description { get; set; }
    public CheckWidgetZoneExistsByDescriptionRequest(string? description)
    {
      Id = Guid.NewGuid();
      Description = description;
    }
  }
}