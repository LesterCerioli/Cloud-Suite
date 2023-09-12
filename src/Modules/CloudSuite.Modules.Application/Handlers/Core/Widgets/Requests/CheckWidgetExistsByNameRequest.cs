using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests
{
  public class CheckWidgetExistsByNameRequest : IRequest<CheckWidgetExistsByNameResponse>
  {
    public Guid Id { get; private set; }  

    public string? Name { get; private set; }
    
    public CheckWidgetExistsByNameRequest(string? name)
    {
      Id = Guid.NewGuid();
      Name = name;
    }
  }
}