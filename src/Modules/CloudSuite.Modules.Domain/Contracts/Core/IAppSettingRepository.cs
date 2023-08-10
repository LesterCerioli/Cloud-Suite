namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface AppSettingRepository
    {
       
        Task<AppSetting> GetByValue(string Value);

        Task<AppSetting> GetByModule(string Module);

        Task<IEnumerable<AppSetting>> GetAll();

        Task Add(AppSetting AppSetting);

        void Update(AppSetting AppSetting);

        void Remove(AppSetting AppSetting);  
    }
}