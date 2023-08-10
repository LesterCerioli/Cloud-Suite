namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface CloudConstantsRepository
    {
         
        Task<CloudConstants> GetByThemeConfigKey(string ThemeConfigKey);

        Task<IEnumerable<CloudConstants>> GetAll();

        Task Add(CloudConstants CloudConstants);

        void Update(CloudConstants CloudConstants);

        void Remove(CloudConstants CloudConstants);

    }
}