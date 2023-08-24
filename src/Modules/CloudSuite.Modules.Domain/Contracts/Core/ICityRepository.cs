using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface ICityRepository
    {
        Task<City> GetByCityName(string cityName);

        Task<IEnumerable<City>> GetList();

        Task Add(City city);

        void Update(City city);

        void Remove(City coty);
    }
}