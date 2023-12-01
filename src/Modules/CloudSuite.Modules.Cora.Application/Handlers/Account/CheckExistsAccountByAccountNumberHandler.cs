using CloudSuite.Modules.Cora.Application.Handlers.Account.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Account;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account
{
    public class CheckExistsAccountByAccountNumberHandler : IRequestHandler<CheckExistsAccountByAccountNumberRequest, CheckExistsAccountByAccountNumberResponse>
    {

        private IAccountRepository _accountRepository;
        private readonly ILogger<CheckExistsAccountByAccountNumberHandler> _logger;

        public CheckExistsAccountByAccountNumberHandler(IAccountRepository accountRepository, ILogger<CheckExistsAccountByAccountNumberHandler> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public async Task<CheckExistsAccountByAccountNumberResponse> Handle(CheckExistsAccountByAccountNumberRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckExistsAccountByAccountNumberRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var accountNumber = await _accountRepository.GetByAccountNumber(request.AccountNumber);


                    if (accountNumber != null)
                    {
                        return await Task.FromResult(new CheckExistsAccountByAccountNumberResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckExistsAccountByAccountNumberResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckExistsAccountByAccountNumberResponse(request.Id, false, validationResult));
        }
    }
}
