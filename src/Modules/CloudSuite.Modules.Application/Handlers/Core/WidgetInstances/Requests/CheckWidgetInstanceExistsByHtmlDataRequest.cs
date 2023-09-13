using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests
{
  public class CheckWidgetInstanceExistsByHtmlDataRequest : IRequest<CheckWidgetInstanceExistsByHtmlDataResponse>
  {
    public Guid Id { get; private set; }

    public string? HtmlData { get; set; }

    public CheckWidgetInstanceExistsByHtmlDataRequest(string? htmlData)
    {
      Id = Guid.NewGuid();
      HtmlData = htmlData;
    }
  }
}