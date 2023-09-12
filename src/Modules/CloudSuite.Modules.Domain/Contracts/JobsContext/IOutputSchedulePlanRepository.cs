using CloudSuite.Modules.Domain.Models.JobsContext;


namespace CloudSuite.Modules.Domain.Contracts.JobsContext
{
    public interface IOutputSchedulePlanRepository
    {
         
         Task<OutputSchedulePlan> GetByName(string name);

         Task<OutputSchedulePlan> GetByIntervalInMinutes(int intervalInMinutes);

         Task<IEnumerable<OutputSchedulePlan>> GetAll();

        Task Add(OutputSchedulePlan outputSchedulePlan);

        void Update(OutputSchedulePlan outputSchedulePlan);

        void Remove(OutputSchedulePlan outputSchedulePlan);
        
    }
}