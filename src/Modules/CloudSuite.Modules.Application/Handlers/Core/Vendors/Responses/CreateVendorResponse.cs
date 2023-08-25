using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses
{
  public class CreateVendorResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateVendorResponse(Guid requestId, ValidationResult result)
    {
      RequestId = requestId;
      
      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CreateVendorResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId ;
      this.AddError(ValidationFailure);
    }  
  }
}