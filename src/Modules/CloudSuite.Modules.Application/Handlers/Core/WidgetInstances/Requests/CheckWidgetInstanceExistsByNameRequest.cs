using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests
{
  public class CheckWidgetInstanceExistsByNameRequest : IRequest<CheckWidgetInstanceExistsByNameResponse>
  {
    public Guid Id { get; private set; }

    public string? Name { get; set; }

    public CheckWidgetInstanceExistsByNameRequest(string? name)
    {
      Id = Guid.NewGuid();
      Name = name;
    }
  }
}