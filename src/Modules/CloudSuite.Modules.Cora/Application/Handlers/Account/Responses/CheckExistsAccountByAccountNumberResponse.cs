using CloudSuite.Modules.Cora.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account.Responses
{
	public class CheckExixtxAccountByAccountNumberResponse : Response
	{
		public Guid RequestId { get; private set; }

		public bool Exists { get; set; }

		public CheckExixtxAccountByAccountNumberResponse(Guid requestId, bool exists)
		{
			RequestId = requestId;
			Exists = exists;
			foreach (var item in Result.Errors)
			{
				this.AddError(item.ErrorMessage);
			}
		}

		public CheckExixtxAccountByAccountNumberResponse(Guid requestId, string falseValidation) 
		{
			RequestId = requestId;
			Exists = false;
			this.AddError(falseValidation);

		}
	}
}
