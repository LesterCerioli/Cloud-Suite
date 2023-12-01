using CloudSuite.Modules.Cora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts
{
	public interface ITransferRepository
	{
		Task<Transfer> GetByAmount(string amount);

		Task<Transfer> GetByCode(string code);

		Task<Transfer> GetByCategory(string category);

		Task<Transfer> GetByBankCodeRecipient(string bankCode);

		Task<Transfer> GetByBranchNumberRecipient(string branchNumber);

		Task<Transfer> GetByAccountNumber(string accountNumber);

		Task<Transfer> GetByScheduled(DateTimeOffset scheduled);

		Task<Transfer> GetByStatus(string status);

		Task<IEnumerable<Transfer>> GetList();

		Task Add(Transfer transfer);

		void Update(Transfer transfer);

		void Remove(Transfer transfer);

		
		
	}
}
