using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface ICountryRepository
    {
        Task<Country> GetByName(string countryName);

        Task<Country> GetByCode(string code3);

        Task<IEnumerable<Country>> GetList();

        Task Add(Country country);

        void Update(Country country);

        void Remove(Country country);
    }
}
