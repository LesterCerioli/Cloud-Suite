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

    public string? Name { get; private set; }

    public string? ViewComponentName { get; private set; }

    public string? CreateUrl { get; private set; }

    public string? EditUrl { get; private set; }

    public bool IsPublished { get; set; }

    public DateTimeOffset? LatestUpdatedOn { get; private set; }

    public DateTimeOffset? CreatedOn { get; private set; }
  }
}