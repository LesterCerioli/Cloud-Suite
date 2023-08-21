using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias.Responses
{
  public class CheckMediaExistsByFileNameResponse : Response
  {
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }

        public CheckMediaExistsByFileNameResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }
        public CheckMediaExistsByFileNameResponse(Guid requestId, string validationFailure)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(validationFailure);
        }

  }

}
