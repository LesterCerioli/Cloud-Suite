using CloudSuite.Modules.Cora.Application.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account.Responses
{
    public class CreateAccountResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateAccountResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;

            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateAccountResponse(Guid requestId, string falseValidation) 
        {
            RequestId = RequestId;
            this.AddError(falseValidation);
        }
    }
}
