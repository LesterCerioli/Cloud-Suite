using CloudSuite.Modules.Domain.Models.Backbone;

namespace CloudSuite.Modules.Domain.Contracts.Backbone
{
    public interface ISystemAccessRepository
    {
        Task<SystemAccess> GetByName(string name);

        Task<SystemAccess> GetByCreatedOn(datetime createdon);

        Task<IEnumerable<SystemAccess>> GetList();

        Task Add(SystemAccess systemAccess);

        void Update(SystemAccess systemAccess);

        void Remove(SystemAccess systemAccess);
         
    }
}