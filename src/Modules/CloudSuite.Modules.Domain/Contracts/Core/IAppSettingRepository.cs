using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface IAppSettingRepository
    {
        Task<AppSetting> GetByValue(string value);

        Task<AppSetting> GetByModule(string module);

        Task<IEnumerable<AppSetting>> GetAll();

        Task Add(AppSetting appSetting);

        void Update(AppSetting appSetting);

        void Remove(AppSetting appSetting);
    }
}
