using CloudSuite.Modules.Domain.Models.Cora.ExtractContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Cora
{
    public interface IExtratoRepository
    {
        Task<Extract> GetByStartDate(DateTimeOffset dataInicio);

        Task<Extract> GetByEndDate(DateTimeOffset dataFinal);

        Task<IEnumerable<Extract>> GetList();

        Task Add(Extract extrato);

        void Update(Extract extrato);

        void Remove(Extract extrato);
    }
}
