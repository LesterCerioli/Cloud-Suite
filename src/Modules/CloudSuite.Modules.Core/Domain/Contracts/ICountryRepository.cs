using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;

namespace CloudSuite.Modules.Core.Domain.Contracts
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