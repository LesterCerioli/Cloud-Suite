using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests
{
  public class CheckWidgetExistsByCreationDateRequest : IRequest<CheckWidgetExistsByCreationDateResponse>
  {
    public Guid Id { get; private set; }  

    public DateTimeOffset CreatedOn { get; private set; }
    
    public CheckWidgetExistsByCreationDateRequest(DateTimeOffset createdOn)
    {
      Id = Guid.NewGuid();
      CreatedOn = createdOn;
    }
  }
}