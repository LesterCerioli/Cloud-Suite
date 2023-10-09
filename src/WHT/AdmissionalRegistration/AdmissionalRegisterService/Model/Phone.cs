using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionalRegisterService.Model
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public int StateCode { get; set; }
        public string Number { get; set; }
        public PhoneType Type { get; set; }
        public string ContactName { get; set; }
    }

    public enum PhoneType
    {
        Residencial = 1,
        Mobile = 2,
        Emergency = 3
    }
}