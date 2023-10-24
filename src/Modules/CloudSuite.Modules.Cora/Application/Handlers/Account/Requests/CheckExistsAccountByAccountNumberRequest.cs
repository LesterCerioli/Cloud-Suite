using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account.Requests
{
	public class CheckExixtxAccountByAccountNumberRequest : IRequest<CheckExixtxAccountByAccountNumberResponse>
	{
        public Guid Id { get; private set; }

		public string? Agency { get; set; }

		public string? AccountNumber { get; set; }

		public string? AccountDigit { get; set; }

		public string? BankName { get; set; }

		public string? BankCode { get; set; }

		public CheckExixtxAccountByAccountNumberRequest(
			string? agency,
			string? bankCode,
			string? accountNumber,
			string? accountDigit,
			string? bankName)
		{
			Id = Guid.NewGuid();
			Agency = agency;
			BankCode = bankCode;
			AccountNumber = accountNumber;
			AccountDigit = accountDigit;
			BankName = bankName;
		}
	}
}
