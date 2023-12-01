using AutoMapper;
using CloudSuite.Modules.Cora.Application.Handlers.Account;
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
	public class AccountAppService : IAccountAppService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMediatorHandler _mediator;
		private readonly IMapper _mapper;

		public AccountAppService(
			IAccountRepository accountRepository,
			IMediatorHandler mediator,
			IMapper mapper)
		{
			_accountRepository = accountRepository;
			_mediator = mediator;
			_mapper = mapper;

		}
		public async Task<AccountViewModel> GetByAccountDigit(string accountDigit)
		{
			return _mapper.Map<AccountViewModel>(await _accountRepository.GetByAccountDigit(accountDigit));
		}

		public async Task<AccountViewModel> GetByAccountNumber(string accountNumber)
		{
			return _mapper.Map<AccountViewModel>(await _accountRepository.GetByAccountNumber(accountNumber));
		}

		public async Task<AccountViewModel> GetByAgency(string agency)
		{
			return _mapper.Map<AccountViewModel>(await _accountRepository.GetByAgency(agency));
		}

		public async Task<AccountViewModel> GetByBankCode(string bankCode)
		{
			return _mapper.Map<AccountViewModel>(await _accountRepository.GetByBankCode(bankCode));
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
		
		public async Task Save(CreateAccountCommand createCommand)
		{
			await _accountRepository.Add(createCommand.GetEntity());
		}
	}
}
