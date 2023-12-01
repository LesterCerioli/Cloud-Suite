using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses
{
    public class CreateTransactionResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateTransactionResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;

            foreach (var item in result.Errors)
            {
                AddError(item.ErrorMessage);
            }
        }

        public CreateTransactionResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            AddError(falseValidation);
        }
    }
}