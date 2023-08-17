using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface ISettingService
    {
        Task<string> GetSettingValueAsync(string name);

        Task<string> GetSettingValueForUserAsync(long userId, string name);

        Task<Dictionary<string, string>> GetAllSettingsAsync();

        Task<Dictionary<string, string>> GetAllSettingsForUserAsync(long userId);

    }
}
