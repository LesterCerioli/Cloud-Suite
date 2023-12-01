using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account.Requests
{
	public class CheckExistsAccountByAccountNumberRequest : IRequest<CheckExistsAccountByAccountNumberResponse>
    {
		public Guid Id { get; private set; }

        public string AccountNumber { get; private set; }


		public CheckExistsAccountByAccountNumberRequest(string accountNumber)
		{
            Id = Guid.NewGuid();
            AccountNumber = accountNumber;
		}
    }
}
