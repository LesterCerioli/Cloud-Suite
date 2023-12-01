﻿using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses
{
    public class CheckTransactionExistByCounterPartyNameResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }


        public CheckTransactionExistByCounterPartyNameResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckTransactionExistByCounterPartyNameResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falseValidation);
        }
    }
}
