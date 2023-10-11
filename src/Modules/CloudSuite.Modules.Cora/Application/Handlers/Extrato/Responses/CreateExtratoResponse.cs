using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Cora.Extrato.Responses
{
    public class CreateExtratoResponse : Response
    {
        public Guid RequestId { get; private set; }

        public bool Success { get; private set; }

        public decimal Amount { get; private set; }

        // espernado a criação da lista nos contratos que traga

        public CreateExtratoResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateExtratoResponse(Guid requestId, string validationFailure)
        {
            RequestId = requestId;
            this.AddError(validationFailure);
        }
    }
}