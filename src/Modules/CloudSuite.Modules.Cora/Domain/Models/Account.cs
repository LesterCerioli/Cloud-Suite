using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Models
{
    public class Account : Entity, IAggregateRoot
    {
        public Account(string? agency, string? accountNumber, 
            string? accountDigit, string? bankName, 
            string? bankCode)
        {
            Agency = agency;
            AccountNumber = accountNumber;
            AccountDigit = accountDigit;
            BankName = bankName;
            BankCode = bankCode;
        }

        public Account() {}
        
        public string? Agency { get; private set; }

        public string? AccountNumber { get; private set; }

        public string? AccountDigit { get; private set; }

        public string? BankName { get; private set; }

        public string? BankCode { get; private set; }
    }
}
