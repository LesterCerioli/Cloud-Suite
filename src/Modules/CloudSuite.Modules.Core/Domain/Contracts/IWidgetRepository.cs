using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;

namespace CloudSuite.Modules.Core.Domain.Contracts
{
    public interface IWidgetRepository
    {
        Task<Widget> GetByName(string name);

        Task<Widget> GetByCreationDate(DateTimeOffset creationDate);

        Task<Widget> GetByLatestUpdatedDate(string createUrl);

        Task<Widget> GetByEditUrl(string editUrl);

        Task<IEnumerable<Widget>> GetList();

        Task Add(Widget widget);

        void Update(Widget widget);

        void Remove(Widget widget);
         
    }
}