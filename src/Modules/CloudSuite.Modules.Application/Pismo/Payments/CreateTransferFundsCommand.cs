using MediatR;
using CloudSuite.Modules.Application.Handlers.Pismo.Request;
using CloudSuite.Modules.Application.Handlers.Pismo.Response;
using CloudSuite.Modules.Application.Handlers.Core.Payments.Responses;

namespace CloudSuite.Modules.Application.Handlers.Pismo
{
    public class CreateTransferFundsCommand : IRequest<CreateTransferFundsResponse>
    {
        public CreateTransferFundsCommand(object[] receiptMethods, object[] transferMethods, float amount, 
                                            string currency, DateTime paymentDateTime, string descriptor)
        {
            From = new List<object>(transferMethods);
            To = new List<object>(receiptMethods);
            Amount = amount;
            Currency = currency;
            PaymentDateTime = paymentDateTime;
            Descriptor = descriptor;
        }

        public List<object> From { get; set; }
        public List<object> To { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public string Descriptor { get; set; }

        public TransferFundsRequest ToTransferFundsRequest()
        {
            return new TransferFundsRequest(
              this.From.ToArray(),
              this.To.ToArray(),
              this.Amount,
              this.Currency,
              this.PaymentDateTime,
              this.Descriptor
            );
        }

    }
}