using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudSuite.Modules.Application.Handlers.Pismo.Response
{
    public class TransferFundsResponse
    {
        public string IdDebit { get; set; }
        public string IdCredit { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Descriptor { get; set; }
        public DateTime? PaymentDateTime { get; set; }

        public TransferFundsResponse(string json)
        {
            JsonConvert.PopulateObject(json, this);
        }

    }
}