using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests
{
  public class CheckWidgetExistsByEditUrlRequest : IRequest<CheckWidgetExistsByEditUrlResponse>
  {
    public Guid Id { get; private set; }  

    public string? EditUrl { get; set; }
    
    public CheckWidgetExistsByEditUrlRequest(string? editUrl)
    {
      Id = Guid.NewGuid();
      EditUrl = editUrl;
    }
  }
}