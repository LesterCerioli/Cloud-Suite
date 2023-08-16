using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using NetDevPack.Data;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class WidgetInstanceService : IWidgetInstanceService
    {
        public IQueryable<WidgetInstance> GetPublished()
        {
            throw new NotImplementedException();
        }
    }
}
