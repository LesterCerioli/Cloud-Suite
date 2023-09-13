using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses
{
  public class CheckWidgetInstanceExistsByNameResponse : Response
  {
    public Guid RequestId { get; private set; }
    
    public bool Exists { get; set; }

    public CheckWidgetInstanceExistsByNameResponse(Guid requestId, bool exists, ValidationResult result)
    {
      RequestId = requestId;
      Exists = exists;
      
      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }
    public CheckWidgetInstanceExistsByNameResponse(Guid requestId, string validationFailure)
    {
      RequestId = requestId;
      Exists = false;
      this.AddError(validationFailure);
    }
  }
}