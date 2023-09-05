using CloudSuite.Modules.Domain.Models.JobsContext;
using CloudSuite.Modules.Domain.Shared.Enums.JobsContext;

namespace CloudSuite.Modules.Domain.Contracts.JobsContext
{
    public interface IJobContextRepositorycs
    {
         
         Task<JobContext> GetByPriority(JobPriority priority);

         Task<JobContext> GetByType(JobType type);

         Task<IEnumerable<JobContext>> GetAll();

         Task Add(JobContext jobContext);

         void Update(JobContext jobContext);

         void Remove(JobContext jobContext);
         
    }
}