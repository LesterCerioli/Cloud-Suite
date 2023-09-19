using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface ICurrencyService
    {
        Task<CurrencyViweModel> GetByFormatCurrency(string formatCurrency);

        Task Save(CreateCurrencyCommand commandCreate);
        
    }
}