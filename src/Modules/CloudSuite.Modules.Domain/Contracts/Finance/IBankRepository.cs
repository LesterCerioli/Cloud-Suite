using CloudSuite.Modules.Domain.Models.Finance;

namespace CloudSuite.Modules.Domain.Contracts.Finance
{
    public interface IBankRepository
    {
         
         Task<Bank> GetByBankName(string bankName);

         Task<Bank> GetByBankCode(string bankCode);

         Task<IEnumerable<Bank>> GetList();

         Task Add(Bank bank);

         void Update(Bank bank);

         void Remove(Bank bank);
         
    }
}