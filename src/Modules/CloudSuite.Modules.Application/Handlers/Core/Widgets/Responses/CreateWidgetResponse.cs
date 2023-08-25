using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses
{
  public class CreateWidgetResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateWidgetResponse(Guid requestId, ValidationResult result)
    {
      RequestId = requestId;
      
      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CreateWidgetResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId ;
      this.AddError(ValidationFailure);
    }  
  }
}