using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Backbone.Credentials.Responses
{
    public class CreateCredentialResponse : Response
    {
        public Guid ResponseId {get; private set; }

        public CreateCredentialResponse(Guid responseId, ValidationResult result)
        {
            ResponseId = responseId;

            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
            
        }

        public CreateCredentialResponse(Guid requestId, string ValidationFailure)
        {
            RequestId = requestId;

            this.AddError(ValidationFailure);
        }


        
    }
}