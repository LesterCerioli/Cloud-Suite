using CloudSuite.Modules.Common.Enums.Fiscal.JobContext;
using CloudSuite.Modules.Domain.Models.Fiscal.JobsContext;
using CloudSuite.Modules.Domain.Models.JobsContext;



namespace CloudSuite.Modules.Domain.Contracts.JobsContext
{
    public interface IJobContextRepositorycs
    {
         
         Task<JobContextModel> GetByPriority(JobPriority priority);

         Task<JobContextModel> GetByType(JobType type);

         Task<IEnumerable<JobContextModel>> GetAll();

         Task Add(JobContextModel jobContextModel);

         void Update(JobContextModel jobContextModel);

         void Remove(JobContextModel jobContextModel);
         
    }
}