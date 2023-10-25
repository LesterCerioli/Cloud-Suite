using CloudSuite.Modules.Cora.Application.Enums;
using CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts
{
        public interface IExtractRepository
        {
            Task<Extract> GetByStartDate(DateTimeOffset dataInicio);

            Task<Extract> GetByEndDate(DateTimeOffset dataFinal);

            Task<Extract> GetByEntryAmount(decimal amount);

            Task<Extract> GetByEntryCreatedAt(string entryCreatedAt);

            Task<Extract> GetByEntryTransactionDescription(string entryTransactionDescription);

            Task<Extract> GetByAggregationsCreditTotal(string aggregationsCreditTotal);

            Task<Extract> GetByAggregationsDebitTotal(string aggregationsDebitTotal);

            Task<IEnumerable<Extract>> GetList();

            Task Add(Extract extract);

            void Update(Extract extract);

            void Remove(Extract extract);
        }
    }
