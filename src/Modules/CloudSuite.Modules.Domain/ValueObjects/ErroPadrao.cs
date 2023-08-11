using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.ValueObjects
{
    public enum ErroPadrao
    {
        ErroNaoDetectado = 0,
        FalhaInternet = 1,
        FalhaEnvioXmlWS = 2,
        CertificadoVencido = 3,
        FalhaEnvioXmlNFeWS = 5
    }
}
