using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Infrastructure;
using CloudSuite.Infrastructure.Data;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class ThemeService : IThemeService
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IRepositoryWithTypedId<AppSetting, string> _appSettingRepository;
        private string _currentThemeName;
        
        public ThemeService(IConfiguration configuration, IRepositoryWithTypedId<AppSetting, string> appSettingRepository)
        {
            _configurationRoot = (IConfigurationRoot)configuration;
            _appSettingRepository = appSettingRepository;
            _currentThemeName = configuration[CloudConstants.ThemeConfigKey];
        }

        public async Task<IList<ThemeListItem>> GetInstalledThemes()
        {
            IList<ThemeListItem> themes = new List<ThemeListItem>
            {
                new ThemeListItem
                {
                    Name = "Generic",
                    DisplayName = "Generic",
                    IsCurrent = "Generic" == _currentThemeName,
                    ThumbnailUrl = "/themes/generic-theme.png"
                }
            };

            var themeRootFolder = new DirectoryInfo(Path.Combine(GlobalConfiguration.ContentRootPath, "Themes"));
            var themeFolders = themeRootFolder.GetDirectories();

            foreach (var themeFolder in themeFolders)
            {
                var themeJsonPath = Path.Combine(themeFolder.FullName, "theme.json");
                
                if (!File.Exists(themeJsonPath))
                {
                    throw new ApplicationException($"Cannot found theme.json for theme {themeFolder.Name}");
                }

                var manifestStr = await File.ReadAllTextAsync(themeJsonPath);
                ThemeManifest themeManifest;
                themeManifest = JsonConvert.DeserializeObject<ThemeManifest>(manifestStr);
                var theme = new ThemeListItem
                {
                    Name = themeManifest.Name,
                    DisplayNameAttribute = themeManifest.DisplayName,
                    IsCurrent = themeManifest.Name == _currentThemeName,
                    ThumbnailUrl = $"/themes{themeManifest.Name}/{themeManifest.Name}.png"
                };

                themes.Add(theme);
            }

            return themes;
        }

        public async Task SetCurrentTheme(string themeName)
        {
            var themeSetting = await _appSettingRepository.Query().Where(x => x.Id == CloudConstants.ThemeConfigKey).FirstAsync();
            themeSetting.Value = themeName;
            await _appSettingRepository.SaveChangesAsync();
            _configurationRoot.Reload();
        }

        public string PackTheme(string themeName)
        {
            var themeFolder = new DirectoryInfo(Path.Combine(GlobalConfiguration.ContentRootPath, "Themes", themeName));
            var themeFolderWWWroot = new DirectoryInfo(Path.Combine(GlobalConfiguration.WebRootPath, "themes", themeName));

            
        }

        public Task Install(Stream stream, string themeName)
        {
            throw new NotImplementedException();
        }

        public void Delete(string themeName)
        {
            throw new NotImplementedException();
        }
    }
}
