using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface ISettingService
    {
        /// <param name="name">Unique name of the setting</param>
        /// <returns>Current value of the setting</returns>
        Task<string> GetSettingValueAsync(string name);

        /// <param name="name">Unique name of the setting</param>
        /// <param name="userId">User id</param>
        /// <returns>Current value of the setting for the user</returns>
        Task<string> GetSettingValueForUserAsync(long userId, string name);

        Task<Dictionary<string, string>> GetAllSettingsAsync();

        /// <param name="userId">UserId</param>
        /// <returns>All settings of the user</returns>
        Task<Dictionary<string, string>> GetAllSettingsForUserAsync(long userId);

        /// <param name="user">User</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        Task UpdateSettingForUserAsync(User user, string name, string value);

        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task UpdateSettingAsync(string name, string value);

        /// <param name="user"></param>
        /// <param name="user">User</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        void SetCustomSettingValueForUser(User user, string name, string value);
    }
}