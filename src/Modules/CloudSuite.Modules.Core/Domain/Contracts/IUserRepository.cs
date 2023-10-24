using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;
using CloudSuite.Modules.Core.Domain.ValueObjects;

namespace CloudSuite.Modules.Core.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(Email email);

        Task<User> GetByCpf(Cpf cpf);

        Task<IEnumerable<User>> GetList();

        Task Add(User user);

        void Update(User user);

        void Remove(User user);
         
    }
}