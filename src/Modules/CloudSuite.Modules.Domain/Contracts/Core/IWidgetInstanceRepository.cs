using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface IWidgetInstanceRepository
    {
        Task<WidgetInstance> GetByName(string name);    
        
        Task<WidgetInstance> GetByWidgetId(string widgetId);

        Task<WidgetInstance> GetByDisplayOrder(int displayOrder);

        Task<WidgetInstance> GetByData(string data);

        Task<WidgetInstance> GetByHtmlData(string htmlData);

        Task<IEnumerable<WidgetInstance>> GetAll();

        Task Add(WidgetInstance widgetInstance);

        void Update(WidgetInstance widgetInstance);

        void Remove(WidgetInstance widgetInstance);
    }
}
