namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface ThemeManifestRepository
    {
         
         Task<ThemeManifest> GetByName(string Name);

         Task<ThemeManifest> GetByFullName(string FullName);

         Task<ThemeManifest> GetByDisplayName(string DisplayName);

         Task<ThemeManifest> GetByVersion(string Version);

         Task<IEnumerable<ThemeManifest>> GetAll();

         Task Add(ThemeManifest ThemeManifest);

         void Update(ThemeManifest ThemeManifest);

         void Remove(ThemeManifest ThemeManifest);
         

    }
}