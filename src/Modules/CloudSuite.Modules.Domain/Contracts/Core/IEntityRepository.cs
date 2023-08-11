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
        Task<Entity> GetBySlug(string slug);

        Task<Entity> GetByName(string name);

        Task<IEnumerable<Entity>> GetAll();

        Task Add(Entity entity);

        void Update(Entity entity);

        void Remove(Entity entity);
    }
}
