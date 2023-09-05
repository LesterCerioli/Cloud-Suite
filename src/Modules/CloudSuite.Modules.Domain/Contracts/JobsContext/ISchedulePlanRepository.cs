using CloudSuite.Modules.Domain.Models.JobsContext;

namespace CloudSuite.Modules.Domain.Contracts.JobsContext
{
    public interface ISchedulePlanRepository
    {
         
         Task<SchedulePlan> GetByName(string name);

         Task<SchedulePlan> GetByScheduledDays(SchedulePlanDaysOfWeek scheduledDays);

        Task<IEnumerable<SchedulePlan>> GetAll();

        Task Add(SchedulePlan schedulePlan);

        void Update(SchedulePlan schedulePlan);

        void Remove(SchedulePlan schedulePlan);
        
    }
}