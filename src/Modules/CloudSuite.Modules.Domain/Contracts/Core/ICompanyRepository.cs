using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface ICompanyRepository
    {
        Task<Company> GetByFantasyName(string fantasyName);

        Task<Company> GetByRegisterName(string registerName);

        Task<IEnumerable<Company>> GetAll();

        Task Add(Company company);

        void Update(Company company);

        void Remove(Company company);
    }
}
