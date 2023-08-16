using CloudSuite.Modules.Domain.Models.Fiscal.NFes;

namespace CloudSuite.Modules.Domain.Contracts.Fiscal.NFes
{
    public interface IBillRepository
    {
        
         Task<Bill> GetByNumber(string number);

         Task<Bill> GetByOriginalValue(decimal originalValue);

         Task<Bill> GetByDiscountValue(decimal discountValue);

         Task<IEnumerable<Bill>> GetList();

         Task Add(Bill bill);

         void Update(Bill bill);

         void Remove(Bill bill);

    }
}