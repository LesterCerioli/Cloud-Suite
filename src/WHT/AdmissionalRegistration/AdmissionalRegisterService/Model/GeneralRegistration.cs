using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionalRegisterService.Model
{
    public class GeneralRegistration
    {
        public int GeneralRegistrationId { get; set; }
        public string Number { get; set; }
        public string EmissionInssuer { get; set; }
        public DateTime? dtExpedition { get; set; }
    }
}