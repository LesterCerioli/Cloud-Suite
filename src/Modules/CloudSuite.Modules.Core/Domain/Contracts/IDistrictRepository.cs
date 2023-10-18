using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;

namespace CloudSuite.Modules.Core.Domain.Contracts
{
    public interface IDistrictRepository
    {
        Task<District> GetByName(string name);

        Task<IEnumerable<District>> GetList();

        Task Add(District district);

        void Update(District district);

        void Remove(District district);
         
    }
}