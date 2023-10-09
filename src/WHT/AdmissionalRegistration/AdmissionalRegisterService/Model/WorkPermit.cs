using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionalRegisterService.Model
{
    public class WorkPermit
    {
        public int WorkPermitId { get; set; }
        public string Number { get; set; }
        public string Series { get; set; }
        public int UfId { get; set; }
        public DateTime? dtExpedition { get; set; }
    }
}