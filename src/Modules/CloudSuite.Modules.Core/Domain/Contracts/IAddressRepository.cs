using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;

namespace CloudSuite.Modules.Core.Domain.Contracts
{
    public interface IAddressRepository
    {
        Task<Address> GetByContactName(string contactName);

        Task<Address> GetByAddressLine(string addressLine1);


        Task<IEnumerable<Address>> GetAll();

        Task Add(Address address);

        void Update(Address address);

        void Remove(Address address);
        
    }
}