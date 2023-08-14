using CloudSuite.Modules.Domain.Models.Fiscal.NFes;
using CloudSuite.Modules.Domain.ValueObjects;


namespace CloudSuite.Modules.Domain.Contracts.Fiscal.NFes
{
    public interface IAccessKeyNFeRepository
    {
         Task<AccessKeyNFe> GetByCnpj(Cnpj cnpj);

         Task<AccessKeyNFe> GetByCompanyName(string companyName);

         Task<IEnumerable<AccessKeyNFe>> GetList();

         Task Add(AccessKeyNFe accessKeyNFe);

         void Update(AccessKeyNFe accessKeyNFe);

         void Remove(AccessKeyNFe accessKeyNFe);


    }
}