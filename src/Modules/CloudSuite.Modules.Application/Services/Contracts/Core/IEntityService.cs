using CloudSuite.Modules.Application.Handlers.Core.Districts;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IEntityService
    {
        Task<EntidadeViewModel> GetBySlug(string slug);

        Task<EntidadeViewModel> GetByName(string name);

        Task Save(CreateDistrictCommand commandCreate);
    }
}