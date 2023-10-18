using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;

namespace CloudSuite.Modules.Core.Domain.Contracts
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