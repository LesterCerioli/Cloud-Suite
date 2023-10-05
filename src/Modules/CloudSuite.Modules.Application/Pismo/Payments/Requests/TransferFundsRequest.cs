using CloudSuite.Modules.Application.Handlers.Pismo.Response;
using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Pismo.Request
{
    public class TransferFundsRequest : IRequest<TransferFundsResponse>
    { 
        public List<object> From { get; set; } = new List<object>();
        public List<object> To { get; set; } = new List<object>();
        public float Amount { get; set; } = 100;
        public string Currency { get; set; } = "BRL";
        public DateTime PaymentDateTime { get; set; }
        public string Descriptor { get; set; } = "Transferência P2P";

        public TransferFundsRequest(object[] receiptMethods, object[] transferMethods, float amount, string currency, DateTime paymentDateTime, string descriptor)
        {
            foreach (var transferMethod in transferMethods)
            {
                From.Add(transferMethod);
            }

            foreach (var receiptMethod in receiptMethods)
            {
                To.Add(receiptMethod);
            }

            Amount = amount;

            Currency = currency;

            PaymentDateTime = paymentDateTime;

            Descriptor = descriptor;

        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
