using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data
{
    public interface IRepositoryWithTypedId<T, TId> where T : IEntityWithTypeId<TId>
    {
        IQueryable<T> Query();

        void Add(T entity);

        void AddRange(IEnumerable<T> entity);

        IDbContextTransaction BeginTransaction();

        void SaveChanges();

        Task SaveChangesAsync();

        void Remove(T entity);
    }
}
