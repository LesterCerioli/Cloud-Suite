using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora
{
	public class ExtractRepository : IExtractRepository
	{
		public Task Add(Extract extract)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByEndDate(DateTimeOffset dataFinal)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByEntryAmount(decimal amount)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByEntryCreatedAt(string entryCreatedAt)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByEntryId(string clientName)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByEntryTransactionCounterPartyIdentity(string counterPartyIdentity)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByEntryTransactionCounterPartyName(string counterPartyName)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByEntryTransactionId(string transactionId)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByEntryTransactionType(TransactionTypeEnum entryTransactionType)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByEntryType(OperationTypeEnum entryType)
		{
			throw new NotImplementedException();
		}

		public Task<Extract> GetByStartDate(DateTimeOffset dataInicio)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Extract>> GetList()
		{
			throw new NotImplementedException();
		}

		public void Remove(Extract extract)
		{
			throw new NotImplementedException();
		}

		public void Update(Extract extract)
		{
			throw new NotImplementedException();
		}
	}
}
