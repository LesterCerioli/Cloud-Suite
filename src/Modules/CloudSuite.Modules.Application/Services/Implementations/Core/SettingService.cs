using CloudSuite.Modules.Application.Handlers.Core.AppSettings;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    internal class SettingService : ISettingService
    {
        public async Task<AppSettingViewModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public async Task Save(CreateAppSettingCommand commandCreate)
        {
            throw new NotImplementedException();
        }
    }
}
