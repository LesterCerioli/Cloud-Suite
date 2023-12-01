using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts
{
        public interface IExtractRepository
        {
            Task<Extract> GetByStartDate(DateTimeOffset startDate);

            Task<Extract> GetByEndDate(DateTimeOffset endDate);
            
            Task<Extract> GetByCustomer(Customer customer);

            
            Task<Extract> GetByEntryAmount(decimal entryAmount);

            Task<IEnumerable<Extract>> GetList();

            Task Add(Extract extract);

            void Update(Extract extract);

            void Remove(Extract extract);
        }
    }
