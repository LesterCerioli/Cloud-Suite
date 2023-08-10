namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface UserRepository
    {
         
         Task<User> GetByFullName(string FullName);

         Task<User> GetByCreatedOn(DateTimeOffset CreatedOn);

         Task<User> GetByLatestUpdatedOn(DateTimeOffset LatestUpdatedOn);

         Task<User> GetByRefreshTokenHash(string RefreshTokenHash);

         Task<User> GetByCulture(string Culture);

         Task<User> GetByExtensionData(string ExtensionData);

         Task<IEnumerable<User>> GetAll();

         Task Add(User User);

         void Update(User User);

         void Remove(User User);

        
    }
}