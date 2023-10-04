using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies.Responses
{
  public class CreateCompanyResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateCompanyResponse(Guid requestId, ValidationResult result)
    {
      RequestId = requestId;

      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }
    
    public CreateCompanyResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId;

      this.AddError(ValidationFailure);
    }
  }
}