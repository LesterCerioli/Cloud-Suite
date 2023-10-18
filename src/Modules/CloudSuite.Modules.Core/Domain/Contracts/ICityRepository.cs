using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;

namespace CloudSuite.Modules.Core.Domain.Contracts
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