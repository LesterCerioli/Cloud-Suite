using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias.Responses
{
  public class CreateMediaResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateMediaResponse(Guid requestId, ValidationResult result)
    {
        RequestId = requestId;
        foreach (var item in result.Errors)
        {
            this.AddError(item.ErrorMessage);
        }
    }

    public CreateMediaResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId ;
      this.AddError(ValidationFailure);
    }  
  }
}