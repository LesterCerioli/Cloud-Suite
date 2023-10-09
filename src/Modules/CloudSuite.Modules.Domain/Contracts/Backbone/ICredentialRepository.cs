using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models.Backbone;
using CloudSuite.Modules.Domain.ValueObjects;

namespace CloudSuite.Modules.Domain.Contracts.Backbone
{
    public interface ICredentialRepository
    {
        Task<Credential> GetByLogin(string login);

        Task<Cpf> GetByCpf(Cpf cpf);

        Task<IEnumerable<Credential>> GetList();

        Task Add(Credential credential);

        void Update(Credential credential);

        void Remove(Credential credential);
    }
}
