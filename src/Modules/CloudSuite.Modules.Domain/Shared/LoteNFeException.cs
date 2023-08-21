using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Shared
{
    public class LoteNFeException : ApplicationException
    {
        internal LoteNFeException(string message)
            : base(message)
        {
        }

        internal LoteNFeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
