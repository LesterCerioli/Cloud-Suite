using CloudSuite.Modules.Domain.Models.Finance;
using CloudSuite.Modules.Domain.Models.Fiscal.NFes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Finance
{
    public interface IEmprestimoRepository
    {
        Task<Emprestimo> GetByValorEmprestimo(string emprestimo);

        Task<Emprestimo> GetByNumMeses(string numMeses);

        Task<Emprestimo> GetByTaxaPercentual(string percentual);

        Task<Emprestimo> GetByValorFinalComJuros(string valorFinalComJuros);

        Task<IEnumerable<Emprestimo>> GetList();

        Task Add(Emprestimo emprestimo);
        void Remove(Emprestimo emprestimo);
        void Update(Emprestimo emprestimo);

    }
}
