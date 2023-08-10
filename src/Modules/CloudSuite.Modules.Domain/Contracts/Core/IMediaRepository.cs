namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface MediaRepository
    {
         
         Task<Media> GetByCaption(string Caption);

         Task<Media> GetByFileName(string FileName);

         Task<IEnumerable<Media>> GetAll();

         Task Add(Media Media);

         void Update(Media Media);

         void Remove(Media Media);
         
    }
}