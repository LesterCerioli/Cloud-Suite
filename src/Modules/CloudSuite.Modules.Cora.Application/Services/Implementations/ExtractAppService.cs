using AutoMapper;
using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato;
using CloudSuite.Modules.Cora.Application.Services.Contracts;
using CloudSuite.Modules.Cora.Application.ViewModels;
using CloudSuite.Modules.Cora.Domain.Contracts;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Services.Implementations
{
	public class ExtractAppService : IExtractAppService
	{
		private readonly IExtractRepository _extractRepository;
		private readonly IMediatorHandler _mediator;
		private readonly IMapper _mapper;

		public ExtractAppService(
			IExtractRepository extractRepository,
			IMediatorHandler mediator,
			IMapper mapper)
		{
			_extractRepository = extractRepository;
			_mediator = mediator;
			_mapper = mapper;
		}
		public async Task<ExtractViewModel> GetByCustomer(Customer customer)
		{
			return _mapper.Map<ExtractViewModel>(await _extractRepository.GetByCustomer(customer));
		}

		public async Task<ExtractViewModel> GetByEndDate(DateTimeOffset endDate)
		{
			return _mapper.Map<ExtractViewModel>(await _extractRepository.GetByEndDate(endDate));
		}

		public async Task<ExtractViewModel> GetByEntryAmount(decimal entryAmount)
		{
			return _mapper.Map<ExtractViewModel>(await _extractRepository.GetByEntryAmount(entryAmount));
		}

		
		public async Task<ExtractViewModel> GetByStartDate(DateTimeOffset startDate)
		{
			return _mapper.Map<ExtractViewModel>(await _extractRepository.GetByStartDate(startDate));
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
		
		public async Task Save(CreateExtractCommand commandCreate)
		{
			await _extractRepository.Add(commandCreate.GetEntity());
		}

		public Task<ExtractViewModel> GetByEntryType(OperationTypeEnum entryType)
		{
			throw new NotImplementedException();
		}
	}
}
