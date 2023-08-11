using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(Email email);

        Task<User> GetByCpf(Cpf cof);

        Task<IEnumerable<User>> GetList();

        Task Add(User user);

        void Update(User user);

        void Remove(User user);
    }
}
