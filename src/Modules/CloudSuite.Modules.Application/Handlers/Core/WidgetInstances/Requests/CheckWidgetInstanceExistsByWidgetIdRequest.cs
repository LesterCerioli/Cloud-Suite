using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests
{
  public class CheckWidgetInstanceExistsByWidgetIdRequest : IRequest<CheckWidgetInstanceExistsByWidgetIdResponse>
  {
    public Guid Id { get; private set; }

    public string? WidgetId { get; set; }

    public CheckWidgetInstanceExistsByWidgetIdRequest(string? widgetId)
    {
      Id = Guid.NewGuid();
      WidgetId = widgetId;
    }
  }
}