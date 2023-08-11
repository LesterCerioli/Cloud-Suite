using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface IStateRepository
    {
        Task<State> GetByName(string stateName);

        Task<State> GetByUF(string uf);

        Task<IEnumerable<State>> GetList();

        Task Add(State state);

        void Update(State state);

        void Remove(State state);
    }
}
