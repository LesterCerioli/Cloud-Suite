using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Responses
{
    public class CreateCustomerGroupResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateCustomerGroupResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateCustomerGroupResponse(Guid requestId, string ValidationFailure)
        {
            RequestId = requestId ;
            this.AddError(ValidationFailure);
        } 
    }
}