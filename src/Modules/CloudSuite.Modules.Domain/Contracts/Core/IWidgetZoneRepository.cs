using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface IWidgetZoneRepository
    {
        Task<WidgetZone> GetByName(string name);

        Task<WidgetZone> GetByDescription(string description);

        Task<IEnumerable<WidgetZone>> GetList();

        Task Add(WidgetZone widgetZone);

        void Update(WidgetZone widgetZone);

        void Remove(WidgetZone widgetZone);
    }
}
