using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies.Responses
{
  public class CheckCompaniesExistsByFantasyNameResponse : Response
  {
    public Guid RequestId { get; private set; }

    public bool Exists { get; set; }

    public CheckCompaniesExistsByFantasyNameResponse(Guid requestId, bool exists, ValidationResult result)
    {
      RequestId = requestId;
      Exists = exists;

      foreach (var item in result.Errors)
      {
        this.AddError(item.ErrorMessage);
      }
    }

    public CheckCompaniesExistsByFantasyNameResponse(Guid requestId, string validationFailure)
    {
      RequestId = requestId;
      Exists = false;
      
      this.AddError(validationFailure);
    }
  }
}