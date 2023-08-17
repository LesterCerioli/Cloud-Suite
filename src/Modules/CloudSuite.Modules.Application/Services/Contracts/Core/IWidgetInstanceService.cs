using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IWidgetInstanceService
    {
        Task<Widget> GetByName(string name);

        Task<Widget> GetByCreationDate(DateTimeOffset creationDate);

        Task<Widget> GetByLatestUpdatedDate(string createUrl);

        Task<Widget> GetByEditUrl(string editUrl);

    }
}
