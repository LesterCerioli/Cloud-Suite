using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Core.Domain.Models
{
    public class ThemeManifest
    {
        public ThemeManifest(string? name, string? fullName, string? displayName, string? version)
        {
            
            Name = name;
            FullName = fullName;
            DisplayName = displayName;
            Version = version;
        }

        public string? Name { get; set; }

        public string? FullName { get; set; }

        public string? DisplayName { get; set; }

        public string? Version { get; set; }
    }
}