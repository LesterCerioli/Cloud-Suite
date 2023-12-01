using System.Text.Json;
using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Account;
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

        public async Task<CreateAccountResponse> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateAccountCommand: {JsonSerializer.Serialize(command)}");

            var validationResult = new CreateAccountCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {

                    var account = command.GetEntity();

                    var accountNumberExists = await _accountRepository.GetByAccountNumber(account.AccountNumber);
                    var accountDigitExists = await _accountRepository.GetByAccountDigit(account.AccountDigit);
                    var accountNameExists = await _accountRepository.GetByBankName(account.BankName);
                    var accountTypeExists = await _accountRepository.GetByBankCode(account.BankCode);

                    if (accountNumberExists == null && accountDigitExists == null && accountNameExists == null && accountTypeExists == null)
                    {
                        await _accountRepository.Add(account);
                        return await Task.FromResult(new CreateAccountResponse(command.Id, validationResult));
                    }
                    else
                    {
                        return await Task.FromResult(new CreateAccountResponse(command.Id, "Account already exists."));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"An error occurred during account creation: {ex.Message}");
                    return await Task.FromResult(new CreateAccountResponse(command.Id, "Failed to process the request."));
                }
            }

            return await Task.FromResult(new CreateAccountResponse(command.Id, validationResult));
        }
    }
}