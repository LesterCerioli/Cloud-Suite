using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings.Responses
{
  public class CreateAppSettingResponse : Response
  {
    public Guid RequestId { get; private set; }

    public CreateAppSettingResponse(Guid requestId, ValidationResult result)
    {
      RequestId = requestId;
      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CreateAppSettingResponse(Guid requestId, string ValidationFailure)
    {
      RequestId = requestId;
      this.AddError(ValidationFailure);
    }
  }
}