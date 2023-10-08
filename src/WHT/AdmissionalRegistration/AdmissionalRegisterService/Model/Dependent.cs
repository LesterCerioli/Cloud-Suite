using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionalRegisterService.Model
{
    public class Dependent
    {
        public int DependentId { get; set; }
        public string Name { get; set; }
        public int Kinship { get; set; }
        public bool IsDependentIRRF { get; set; }
        public DateTime dtBirth { get; set; }
        public string TaxPayerRegistry { get; set; }
    }
}