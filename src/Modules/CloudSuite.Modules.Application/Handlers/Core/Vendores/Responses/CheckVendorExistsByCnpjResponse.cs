using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses
{
  public class CheckVendorExistsByCnpjResponse : Response
  {
    public Guid RequestId { get; private set; }
    public bool Exists { get; set; }

    public CheckVendorExistsByCnpjResponse(Guid requestId, bool exists, ValidationResult result)
    {
      RequestId = requestId;
      Exists = exists;
      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }
    public CheckVendorExistsByCnpjResponse(Guid requestId, string validationFailure)
    {
      RequestId = requestId;
      Exists = false;
      this.AddError(validationFailure);
    }
  }
}