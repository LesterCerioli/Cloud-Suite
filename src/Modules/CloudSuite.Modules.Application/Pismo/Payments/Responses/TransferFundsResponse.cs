using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudSuite.Modules.Application.Handlers.Pismo.Response
{
    public class TransferFundsResponse
    {
        public object AuthorizationIds { get; set; }
        public DateTime EventDate { get; set; }
        public float AvailableCreditLimit { get; set; }

        public TransferFundsResponse(string json)
        {
            JsonConvert.PopulateObject(json, this);
            //O construtor usa a biblioteca Newtonsoft.Json para desserializar o JSON em um objeto TransferFundsResponse.
        }

    }
}