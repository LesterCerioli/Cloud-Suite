using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extrato.Responses
{
    public class CreateExtractResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateExtractResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;

            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateExtractResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            this.AddError(falseValidation);
        }

    }
}
