using CloudSuite.Modules.Cora.Application.Handlers.Account.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account
{
	public class CheckAccountExistsByDigitAccountHandlers : IRequestHandler<CheckAccountExistsByDigitAccountRequest, CheckAccountExistsByDigitAccountResponse>
	{
		public CheckAccountExistsByDigitAccountHandlers()
		{

		}

		public async Task<CheckAccountExistsByDigitAccountResponse> Handle(CheckAccountExistsByDigitAccountRequest request, CancellationToken cancellationToken)
		{
			return await Task.FromResult(new CheckAccountExistsByDigitAccountResponse(request.Id, false, validationResult));
		}
	}
}
