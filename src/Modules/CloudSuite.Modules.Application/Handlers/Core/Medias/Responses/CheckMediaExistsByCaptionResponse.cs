using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias.Responses
{
  public class CheckMediaExistsByCaptionResponse : Response
  {
    public Guid RequestId { get; private set; }

    public bool Exists { get; set; }


    public CheckMediaExistsByCaptionResponse(Guid requestId, bool exists, ValidationResult result)
    {
      RequestId = requestId;
      Exists = exists;

      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CheckMediaExistsByCaptionResponse(Guid requestId, string validationFailure)
    {
      RequestId = requestId;
      Exists = false;
      this.AddError(validationFailure);
    }
  }
}