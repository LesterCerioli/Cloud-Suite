using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses
{
  public class CreateWidgetInstanceResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateWidgetInstanceResponse(Guid requestId, ValidationResult result)
    {
      RequestId = requestId;

      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CreateWidgetInstanceResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId;
      this.AddError(ValidationFailure);
    }
  }
}