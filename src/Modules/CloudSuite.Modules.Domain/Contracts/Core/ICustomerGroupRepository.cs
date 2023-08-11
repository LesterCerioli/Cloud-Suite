using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface ICustomergroupRepository
    {
        Task<CustomerGroup> GetByName(Name name);

        Task<CustomerGroup> GetByCreatedOn(DateTimeOffset createOn);

        Task<CustomerGroup> GetByLatestUpdatedOn(DateTimeOffset latestUpdatedOn);

        Task<IEnumerable<CustomerGroup>> GetList();

        Task Add(CustomerGroup customerGroup);

        void Update(CustomerGroup customerGroup);

        void Remove(CustomerGroup customerGroup);

        
    }
}
