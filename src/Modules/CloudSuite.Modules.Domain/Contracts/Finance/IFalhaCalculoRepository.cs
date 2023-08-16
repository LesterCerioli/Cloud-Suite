using CloudSuite.Modules.Domain.Models.Finance;

namespace CloudSuite.Modules.Domain.Contracts.Finance
{
    public interface IFalhaCalculoRepository
    {
         
         Task<FalhaCalculo> GetByMensagem(string mensagem);

         Task<IEnumerable<FalhaCalculo>> GetList();

         Task Add(FalhaCalculo falhaCalculo);

         void Update(FalhaCalculo falhaCalculo);

         void Remove(FalhaCalculo falhaCalculo);
         
    }
}