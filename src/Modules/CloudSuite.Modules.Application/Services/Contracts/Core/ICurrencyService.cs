using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface ICurrencyService
    {
        CultureInfo CurrencyCulture { get; }

        string FormatCurrency(decimal value);
    }
}
