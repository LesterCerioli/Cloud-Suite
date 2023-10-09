using CloudSuite.Modules.Domain.Models.Backbone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Modules.Domain.Contracts.Backbone
{
    public interface ISystemAccessRepository
    {
        Task<SystemAccess> GetByName(string name);

        Task<SystemAccess> GetByCreatedOn(DateTimeOffSet createdOn);

        Task<IEnumerable<SystemAccess>> GetList();

        Task Add(SystemAccess systemAccess);

        void Update(SystemAccess systemAccess);

        void Remove(SystemAccess systemAccess);
         
    }
}