using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface IEntityRepository
    {
        Task<Entidade> GetBySlug(string slug);

        Task<Entidade> GetByName(string name);

        Task<IEnumerable<Entidade>> GetAll();

        Task Add(Entidade entity);

        void Update(Entidade entity);

        void Remove(Entidade entity);
    }
}
