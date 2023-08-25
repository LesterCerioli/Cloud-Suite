using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses
{
  public class CheckWidgetExistsByCreationDateResponse : Response
  {
    public Guid RequestId { get; private set; }
    public bool Exists { get; set; }

    public CheckWidgetExistsByCreationDateResponse(Guid requestId, bool exists, ValidationResult result)
    {
      RequestId = requestId;
      Exists = exists;
      
      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }
    public CheckWidgetExistsByCreationDateResponse(Guid requestId, string validationFailure)
    {
      RequestId = requestId;
      Exists = false;
      this.AddError(validationFailure);
    }
  }
}