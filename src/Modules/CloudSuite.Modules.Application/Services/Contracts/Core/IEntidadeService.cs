using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models.Core;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IEntidadeService
    {
        Task<Entidade> GetBySlug(string slug);

        Task<Entidade> GetByName(string name);

        // Task Save();
    }
}
