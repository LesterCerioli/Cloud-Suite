namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface ContentRepository
    {
        Task<Content> GetByName(string Name);

        Task<Content> GetBySlug(string Slug);

        Task<Content> GetByMetaKeywords (string MetaKeywords);

        Task<Content> GetByMetaDescription (string MetaDescription);

        Task<IEnumerable<Content>> GetAll();

        Task Add(Content Content);

        void Update(Content Content);

        void Remove(Content Content);   
    }
}