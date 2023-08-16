using CloudSuite.Modules.Domain.Models.Finance;

namespace CloudSuite.Modules.Domain.Contracts.Finance
{
    public interface IEmprestimoRepository
    {
         
         Task<Emprestimo> GetByValorEmprestimo(double valorEmprestimo);

         Task<Emprestimo> GetByNumMeses(int NumMeses);

         Task<Emprestimo> GetByTaxaPercentual(double taxaPercentual);

         Task<Emprestimo> GetByValorFinalComJuros(double valorFinalComJuros);

         Task<IEnumerable<Emprestimo>> GetList();

         Task Add(Emprestimo emprestimo);

         void Update(Emprestimo emprestimo);

         void Remove(Emprestimo emprestimo);
         
    }
}