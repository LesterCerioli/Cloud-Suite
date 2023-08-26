using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    internal interface IWidgetInstanceService
    {
        IQueryable<WidgetInstance> GetPublished();
    }
}
