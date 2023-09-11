using CloudSuite.Modules.Domain.Models.JobsContext;


namespace CloudSuite.Modules.Domain.Contracts.JobsContext
{
    public interface ISchedulePlanRepository
    {
         
         Task<SchedulePlan> GetByName(string name);

         Task<SchedulePlan> GetByIntervalInMinutes(int intervalInMinutes);

         Task<SchedulePlan> GetByStartTimespan(int startTimespan);

         Task<SchedulePlan> GetByEndTimespan(int endTimespan);

        Task<IEnumerable<SchedulePlan>> GetAll();

        Task Add(SchedulePlan schedulePlan);

        void Update(SchedulePlan schedulePlan);

        void Remove(SchedulePlan schedulePlan);
        
    }
}