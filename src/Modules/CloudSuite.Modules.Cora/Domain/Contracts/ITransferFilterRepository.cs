using CloudSuite.Modules.Cora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts
{
	public interface ITransferFilterRepository
	{
		Task<TransferFilter> GetByStartDate(DateTime startDate);

		Task<TransferFilter> GetByEndDate(DateTime endDate);

		Task<TransferFilter> GetByPage(string page);

		Task<IEnumerable<TransferFilter>> GetList();

		Task Add(TransferFilter transferFilter);

		void Update(TransferFilter transferFilter);

		void Remove(TransferFilter transferFilter);
	}
}
