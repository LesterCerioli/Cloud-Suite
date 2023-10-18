using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;

namespace CloudSuite.Modules.Core.Domain.Contracts
{
    public interface IVendorRepository
    {
        Task<Vendor> GetByCnpj(Cnpj cnpj);

        Task<Vendor> GetByName(string name);

        Task<Vendor> GetByCreationDate(DateTimeOffset creationDate);

        Task<IEnumerable<Vendor>> GetList();

        Task Add(Vendor vendor);

        void Update(Vendor vendor);

        void Remove(Vendor vendor);
         
    }
}