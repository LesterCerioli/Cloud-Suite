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
        private readonly UserManager<User> _userManager;
        private readonly SettingDefinitionProvider _settingDefinitionProvider
    }
}
