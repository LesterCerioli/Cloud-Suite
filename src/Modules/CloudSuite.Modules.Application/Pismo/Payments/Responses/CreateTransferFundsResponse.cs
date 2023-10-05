using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Core.Payments.Responses
{
    public class CreateTransferFundsResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Success { get; set; }
        public string TrackingId { get; set; }
        public decimal AvailableCreditLimit { get; set; }

        public CreateTransferFundsResponse(Guid requestId, bool success, string trackingId, decimal availableCreditLimit, ValidationResult result)
        {
            RequestId = requestId;
            Success = success;
            TrackingId = trackingId;
            AvailableCreditLimit = availableCreditLimit;

            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateTransferFundsResponse(Guid requestId, string validationFailure)
        {
            RequestId = requestId;
            Success = false;
            TrackingId = null;
            AvailableCreditLimit = 0;
            this.AddError(validationFailure);
        }
    }
}