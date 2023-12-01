using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Account;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato;
using CloudSuite.Modules.Cora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Services.Contracts
{
    public interface IExtractAppService
    {
        Task<ExtractViewModel> GetByStartDate(DateTimeOffset startDate);

        Task<ExtractViewModel> GetByEndDate(DateTimeOffset endDate);

        Task<ExtractViewModel> GetByCustomer(Customer customer);

        Task<ExtractViewModel> GetByEntryType(OperationTypeEnum entryType);

        Task<ExtractViewModel> GetByEntryAmount(decimal entryAmount);

        Task Save(CreateExtractCommand commandCreate);
         
    }
}