using CloudSuite.Modules.Domain.Models.JobsContext;

namespace CloudSuite.Modules.Domain.Contracts.JobsContext
{
    public interface IJobTypeRepository
    {
         
         Task<JobType> GetByName(string name);

         Task<IEnumerable<JobType>> GetAll();

         void Update(JobType jobType);

         void Remove(JobType jobType);
         
    }
}