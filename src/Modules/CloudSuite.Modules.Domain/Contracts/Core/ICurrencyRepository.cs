namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface ICurrencyRepository
    {
        Task<Currency> GetByFormatCurrency(string formatCurrency);

        Task<Currency> GetByCurrencyInfo(streing currencyInfo);
        
        Task<IEnumerable<Currency>> GetList();

        Task Add(Currency currency);

        void Update(Currency currency);

        void Remove(Currency currency);
    }
}