using CloudSuite.Modules.Domain.Models.JobsContext;

namespace CloudSuite.Modules.Domain.Contracts.JobsContext
{
    public interface IJobSetting
    {
         Task<JobSetting> GetByDbConnectinString(string dbConnectinString);

         Task<IEnumerable<JobSetting>> GetAll();

         Task Add(JobSetting jobSetting);

         void Update(JobSetting jobSetting);

         void Remove(JobSetting jobSetting);
    }
}