using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<CreateAccountHandler> _logger;

        public CreateAccountHandler(IAccountRepository accountRepository, ILogger<CreateAccountHandler> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }
        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}