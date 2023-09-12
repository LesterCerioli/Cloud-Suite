using WidgetInstanceEntity = CloudSuite.Modules.Domain.Models.Core.WidgetInstance;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances
{
  public class CreateWidgetInstanceCommand : IRequest<CreateWidgetInstanceResponse>
  {
    public CreateWidgetInstanceCommand()
    {
      Id = Guid.NewGuid();
    }

    public WidgetInstanceEntity GetEntity()
    {
      return new WidgetInstanceEntity(
        this.Name
      );
    }


    public Guid Id { get; private set; }

    public string? Name { get; set; }
  }
}