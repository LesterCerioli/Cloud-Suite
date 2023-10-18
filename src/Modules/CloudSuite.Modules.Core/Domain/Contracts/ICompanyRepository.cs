using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;

namespace CloudSuite.Modules.Core.Domain.Contracts
{
    public interface ICompanyRepository
    {
        Task<Company> GetByCnpj(Cnpj cnpj);

        Task<Company> GetByFantasyName(string fantasyName);

        Task<Company> GetByRegisterName(string registerName);

        Task<IEnumerable<Company>> GetAll();

        Task Add(Company company);

        void Update(Company company);

        void Remove(Company company);
         
    }
}