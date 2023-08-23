using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Users.Responses
{
    public class CreateUserResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateUserResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateUserResponse(Guid requestId, string ValidationFailure)
        {
            RequestId = requestId ;
            this.AddError(ValidationFailure);
        }    
    }
}