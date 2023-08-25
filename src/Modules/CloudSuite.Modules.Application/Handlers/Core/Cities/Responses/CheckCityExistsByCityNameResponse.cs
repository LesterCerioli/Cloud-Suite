using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Cities.Responses
{
  public class CheckCityExistsByCityNameResponse : Response
  {
    public Guid RequestId { get; private set; }

    public bool Exists { get; set; }

    public CheckCityExistsByCityNameResponse(Guid requestId, bool exists, ValidationResult result)
    {
      RequestId = requestId;
      Exists = exists;

      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CheckCityExistsByCityNameResponse(Guid requestId, string validationFailure)
    {
      RequestId = requestId;
      Exists = false;
      this.AddError(validationFailure);
    }
  }
}