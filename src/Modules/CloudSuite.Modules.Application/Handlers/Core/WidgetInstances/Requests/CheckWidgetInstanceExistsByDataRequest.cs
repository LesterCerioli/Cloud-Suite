using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests
{
  public class CheckWidgetInstanceExistsByDataRequest : IRequest<CheckWidgetInstanceExistsByDataResponse>
  {
    public Guid Id { get; private set; }

    public string? Data { get; set; }

    public CheckWidgetInstanceExistsByDataRequest(string? data)
    {
      Id = Guid.NewGuid();
      Data = data;
    }
  }
}