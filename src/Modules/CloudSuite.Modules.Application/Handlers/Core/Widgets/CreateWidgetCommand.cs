using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using WidgetEntity = CloudSuite.Modules.Domain.Models.Core.Widget;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets
{
  public class CreateWidgetCommand : IRequest<CreateWidgetResponse>
  {
    public CreateWidgetCommand()
    {
      Id = Guid.NewGuid();
    }

    public WidgetEntity GetEntity()
    {
      return new WidgetEntity(
        this.Name,
        this.ViewComponentName,
        this.CreateUrl,
        this.EditUrl,
        this.IsPublished
      );
    }

    public Guid Id { get; private set; }

    public string? Name { get; set; }

    public string? ViewComponentName { get; set; }

    public string? CreateUrl { get; set; }

    public string? EditUrl { get; set; }

    public bool IsPublished { get; set; }

    public DateTimeOffset? LatestUpdatedOn { get; set; }

    public DateTimeOffset? CreatedOn { get; set; }
  }
}