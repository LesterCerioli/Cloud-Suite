using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses
{
  public class CreateRoboEmailResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateRoboEmailResponse(Guid requestId, ValidationResult result)
    {
      RequestId = requestId;
      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CreateRoboEmailResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId;
      this.AddError(ValidationFailure);
    }
  }
}