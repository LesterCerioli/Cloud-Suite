using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionalRegisterService.Model
{
    public class Benefit
    {
        public int BenefitId { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}