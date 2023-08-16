using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.AspNetCore.Identity;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class SettingService : ISettingService
    {
        public Task<Dictionary<string, string>> GetAllSettingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, string>> GetAllSettingsForUserAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSettingValueAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSettingValueForUserAsync(long userId, string name)
        {
            throw new NotImplementedException();
        }

        public void SetCustomSettingValueForUser(User user, string name, string value)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSettingAsync(string name, string value)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSettingForUserAsync(User user, string name, string value)
        {
            throw new NotImplementedException();
        }
    }
}
