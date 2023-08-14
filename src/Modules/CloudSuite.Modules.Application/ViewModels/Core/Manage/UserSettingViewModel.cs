using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels.Core.Manage
{
    internal class UserSettingViewModel
    {
        public UserSettingViewModel()
        {
            UserSettings = new Dictionary<string, string>();
            SettingDefinitions = new Dictionary<string, SettingDefinition>();
        }

        public Dictionary<string, SettingDefinition> SettingDefinitions { get; set; }

        public Dictionary<string, string> UserSettings { get; set; }
    }
}
