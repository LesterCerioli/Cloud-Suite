using CloudSuite.Modules.Cora.Application.Core;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extrato.Responses
{
    public class CreateExtractResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateExtractResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;

            foreach (var item in result.Error)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateExtractResponse(Guid requestId, string falseValidation)
        {
            RequestId = RequestId;
            this.AddError(falseValidation);
        }
    }
}