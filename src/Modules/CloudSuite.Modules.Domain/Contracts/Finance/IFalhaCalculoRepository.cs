using CloudSuite.Modules.Domain.Models.Finance;
using CloudSuite.Modules.Domain.Models.Fiscal.NFes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Finance
{
    public interface IFalhaCalculoRepository
    {
        Task<FalhaCalculo> GetByErro(string erro);
        Task<FalhaCalculo> GetByMensagem(string mensagem);

        Task<IEnumerable<FalhaCalculo>> GetList();

        Task Add(FalhaCalculo falhaCalculo);
        void Update(FalhaCalculo falhaCalculo);
        void Remove(FalhaCalculo falhaCalculo);
    }
}
