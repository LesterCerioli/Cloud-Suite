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
    public class TransferFundsRequest: IRequest<TransferFundsResponse>
    {
        public List<Dictionary<string, object>> From { get; set; } = new List<Dictionary<string, object>>();
        public List<Dictionary<string, object>> To { get; set; } = new List<Dictionary<string, object>>();
        public double Amount { get; set; } = 100;
        public string Currency { get; set; } = "BRL";
        public string Descriptor { get; set; } = "Transferência P2P";

        public TransferFundsRequest(object idFromAccount, object idToAccount)
        {
            From.Add(new Dictionary<string, object>()
            {
                {"account", new Dictionary<string, object>(){{"id", idFromAccount} }}
            });

            To.Add(new Dictionary<string, object>()
            {
                {"account", new Dictionary<string, object>(){{"id", idToAccount} }}
            });
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal ValidationResult Validate(TransferFundsRequest request) // valdiation vem da pasta validation
        {
            throw new NotImplementedException();
        }
    }
}
