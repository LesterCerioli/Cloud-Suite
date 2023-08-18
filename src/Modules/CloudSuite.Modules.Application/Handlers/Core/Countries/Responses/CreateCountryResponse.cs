using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Countries.Responses
{
  public class CreateCountryResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateCountryResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateCountryResponse(Guid requestId, string ValidationFailure)
        {
            RequestId = requestId ;
            this.AddError(ValidationFailure);
        }
    }
}
