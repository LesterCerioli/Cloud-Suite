using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using Microsoft.Extensions.Configuration;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class CurrencyService : ICurrencyService
    {
        public CultureInfo CurrencyCulture => throw new NotImplementedException();

        public string FormatCurrency(decimal value)
        {
            throw new NotImplementedException();
        }
    }
}
