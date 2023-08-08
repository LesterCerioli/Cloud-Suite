using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface ICityRepository
    {
        Task<City> GetByCityName();

        Task Add(City city);

        void Update(City city);

        void Remove(City city);
    }
}
