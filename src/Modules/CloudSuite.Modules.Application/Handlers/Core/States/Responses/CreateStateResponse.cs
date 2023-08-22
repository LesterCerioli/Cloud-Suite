using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.States.Responses
{
    public class CreateStateResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateStateResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateStateResponse(Guid requestId, string ValidationFailure)
        {
            RequestId = requestId ;
            this.AddError(ValidationFailure);
        }    
    }
}