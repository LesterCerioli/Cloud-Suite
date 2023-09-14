using WidgetInstanceEntity = CloudSuite.Modules.Domain.Models.Core.WidgetInstance;
using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
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

    public string? WidgetId { get; set; }

    public int? DisplayOrder { get; set; }

    public string? Data { get; set; }

    public string? HtmlData { get; set; }
  }
}