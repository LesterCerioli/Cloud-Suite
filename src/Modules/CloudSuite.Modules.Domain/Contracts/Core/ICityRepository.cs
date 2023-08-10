namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface City
    {
         
        Task<City> GetByCityName(string CityName);

        Task<City> GetByStateId(long StateId);

        Task<City> GetByState(State State);

        Task<IEnumerable<City>> GetAll();

        Task Add(City city);

        void Update(City city);

        void Remove(City city);


    }
}