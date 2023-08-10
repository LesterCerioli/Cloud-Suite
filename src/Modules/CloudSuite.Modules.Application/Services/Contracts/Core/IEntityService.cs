using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IEntityService
    {
        string ToSafeSlug(string slug, long entityId, string entityTypeId);

        Entity Get(long entityId, string entityTypeId);

        void Add(string name, string slug, long entityId, string entityTypeId);

        void Update(string newName, string newSlug, long entityId, string entityTypeId);

        Task Remove(long entityId, string entityTypeId);
    }
}
