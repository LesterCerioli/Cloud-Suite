using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Token.Responses
{
  public class SendTokenReponse : Response
  {
    public Guid RequestId { get; set; }
    public bool Created { get; set; }
    public SendTokenReponse(Guid requestId, ValidationResult validationResult, bool created)
    {
      RequestId = requestId;
      Created = created;

      foreach (var item in validationResult.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public SendTokenReponse(Guid requestId, string validationFailure, bool isValid)
    {
      RequestId = requestId;
      Created = isValid;

      this.AddError(validationFailure);
    }
    
    public SendTokenReponse(Guid requestId, bool isValid)
    {
      RequestId = requestId;
      Created = isValid;
    }
  }
}