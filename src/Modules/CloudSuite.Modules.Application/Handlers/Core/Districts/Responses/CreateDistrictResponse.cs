using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Districts.Responses
{
  public class CreateDistrictResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateDistrictResponse(Guid requestId, ValidationResult result)
    {
      RequestId = requestId;
      
      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CreateDistrictResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId;
      this.AddError(ValidationFailure);
    }
  }
}