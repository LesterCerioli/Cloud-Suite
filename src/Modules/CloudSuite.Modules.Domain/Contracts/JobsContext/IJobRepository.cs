using CloudSuite.Modules.Domain.Models.JobsContext;
using CloudSuite.Modules.Domain.Shared.Enums.JobsContext;

namespace CloudSuite.Modules.Domain.Contracts.JobsContext
{
    public interface IJobRepository
    {
        
         Task<Job> GetByType(JobType type);

         Task<Job> GetByStatus(JobStatus status);

         Task<Job> GetByPriority(JobPriority priority);

         Task<IEnumerable<Job>> GetAll();

         Task Add(Job job);

         void Update(Job job);

         void Remove(Job job);
         
    }
}