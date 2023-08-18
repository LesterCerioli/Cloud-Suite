using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface ICustomerGroupUserRepository
    {
        Task<CustomerGroupUser> GetByName(Name name);

        Task<CustomerGroupUser> GetByCpf(Cpf cpf);

        Task<IEnumerable<CustomerGroupUser>> GetList();

        Task Add(CustomerGroupUser customerGroupUser);
    }
}
