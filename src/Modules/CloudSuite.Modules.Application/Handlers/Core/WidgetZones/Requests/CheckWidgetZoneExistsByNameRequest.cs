using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Requests
{
  public class CheckWidgetZoneExistsByNameRequest : IRequest<CheckWidgetZoneExistsByNameResponse>
  {
    public Guid Id { get; private set; }  
    public string? Name { get; set; }
    public CheckWidgetZoneExistsByNameRequest(string? name)
    {
      Id = Guid.NewGuid();
      Name = name;
    }
  }
}