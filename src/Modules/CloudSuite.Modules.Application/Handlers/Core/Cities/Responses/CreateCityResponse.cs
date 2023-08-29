using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Cities.Responses
{
  public class CreateCityResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateCityResponse(Guid requestId, ValidationResult result)
    {
      RequestId = requestId;

      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }
    
    public CreateCityResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId;
      this.AddError(ValidationFailure);
    }
  }
}