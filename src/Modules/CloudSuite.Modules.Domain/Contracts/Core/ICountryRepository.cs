namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface CountryRepository
    {

        Task<Country> GetByCountryName(string CountryName);

        Task<Country> GetByCode3(string Code3);

        Task<IEnumerable<Country>> GetAll();

        Task Add(Country country);

        void Update(Country country);

        void Remove(Country country);

    }
}