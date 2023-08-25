using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests
{
  public class CheckWidgetExistsByLatestUpdatedDateRequest : IRequest<CheckWidgetExistsByLatestUpdatedDateResponse>
  {
    public Guid Id { get; private set; }

    public string? CreateUrl { get; private set; }
    
    public CheckWidgetExistsByLatestUpdatedDateRequest(string? createUrl)
    {
      Id = Guid.NewGuid();
      CreateUrl = createUrl;
    }
  }
}