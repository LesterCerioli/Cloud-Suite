using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudSuite.Modules.Application.Handlers.Pismo.Response
{
    public class TransferFundsResponse
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string StatusDescription { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Descriptor { get; set; }
        public DateTime? PaymentDateTime { get; set; }

        public TransferFundsResponse(string json)
        {
            JsonConvert.PopulateObject(json, this);
        }

        public TransferFundsResponse()
        {
        }

        public static implicit operator HttpResponseMessage(TransferFundsResponse v)
        {
            throw new NotImplementedException();
        }
    }
}