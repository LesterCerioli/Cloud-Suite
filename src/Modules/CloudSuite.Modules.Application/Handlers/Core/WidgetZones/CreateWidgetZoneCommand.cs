using WidgetZoneEntity = CloudSuite.Modules.Domain.Models.Core.WidgetZone;
using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetZones
{
  public class CreateWidgetZoneCommand : IRequest<CreateWidgetZoneResponse>
  {
    public CreateWidgetZoneCommand()
    {
      Id = Guid.NewGuid();
    }

    public WidgetZoneEntity GetEntity()
    {
      return new WidgetZoneEntity(
        this.Id,
        this.Name,
        this.Description
      );
    }

    public Guid Id { get; private set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
  }
}