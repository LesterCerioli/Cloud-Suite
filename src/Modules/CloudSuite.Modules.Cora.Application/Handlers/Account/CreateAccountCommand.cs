using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountEntity = CloudSuite.Modules.Cora.Domain.Models.Account;



namespace CloudSuite.Modules.Cora.Application.Handlers.Account
{
    public class CreateAccountCommand : IRequest<CreateAccountResponse>
    {
        public Guid Id { get; private set; }

        public string? Agency { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountDigit { get; set; }
        public string? BankName { get; set; }
        public string? BankCode { get; set; }

        public AccountEntity GetEntity()
        {
            return new AccountEntity(
                this.AccountNumber,
                this.AccountDigit,
                this.Agency,
                this.BankName,
                this.BankCode
                );
            
        }
    }
}
