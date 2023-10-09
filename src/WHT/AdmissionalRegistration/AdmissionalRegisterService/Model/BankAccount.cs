using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionalRegisterService.Model
{
    public class BankAccount
    {
        public int? BankId { get; set; }
        public string Branch { get; set; }
        public string BranchDigit { get; set; }
        public string Account { get; set; }
        public string AccountDigit { get; set; }
    }
}