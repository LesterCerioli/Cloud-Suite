namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface StateRepository
    {
         
         Task<State> GetByStateName(string StateName);

         Task<State> GetByUF(string UF);

         Task<IEnumerable<State>> GetAll();

         Task Add(State State);

         void Update(State State);

         void Remove(State State);
         
    }
}