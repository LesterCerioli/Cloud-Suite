using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Responses
{
  public class CreateWidgetZoneResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateWidgetZoneResponse(Guid requestId, ValidationResult result)
    {
      RequestId = requestId;
      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CreateWidgetZoneResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId ;
      this.AddError(ValidationFailure);
    }  
  }
}