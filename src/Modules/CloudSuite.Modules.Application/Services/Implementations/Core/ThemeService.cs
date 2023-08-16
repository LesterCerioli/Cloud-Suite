using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class ThemeService : IThemeService
    {
        public void Delete(string themeName)
        {
            throw new NotImplementedException();
        }

        public Task Install(Stream stream, string themeName)
        {
            throw new NotImplementedException();
        }

        public string PackTheme(string themeName)
        {
            throw new NotImplementedException();
        }

        public Task SetCurrentTheme(string themeName)
        {
            throw new NotImplementedException();
        }
    }

}
