using CloudSuite.Modules.Application.Handlers.Core.AppSettings;
using CloudSuite.Modules.Application.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface ISettingService
    {
        Task<AppSettingViewModel> GetByValue(string value);

        Task Save(CreateAppSettingCommand commandCreate);
        
    }
}