using CloudSuite.Infrastructure.Data.Repositories.Cora;
using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Transaction;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions
{
    public class CheckTransactionExistByCounterPartyNameHandler : IRequestHandler<CheckTransactionExistByCounterPartyNameRequest, CheckTransactionExistByCounterPartyNameResponse>
    {

        private TransactionRepository _transactionRepository;
        private readonly ILogger<CheckTransactionExistByCounterPartyNameHandler> _logger;

        public CheckTransactionExistByCounterPartyNameHandler(TransactionRepository transactionRepository, ILogger<CheckTransactionExistByCounterPartyNameHandler> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<CheckTransactionExistByCounterPartyNameResponse> Handle(CheckTransactionExistByCounterPartyNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransactionExistByCounterPartyNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransactionExistByCounterPartyNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var transactionOrderExist = await _transactionRepository.GetByCounterPartyName(request.EntryTransactionCounterPartyName);


                    if (transactionOrderExist != null)
                    {
                        return await Task.FromResult(new CheckTransactionExistByCounterPartyNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransactionExistByCounterPartyNameResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckTransactionExistByCounterPartyNameResponse(request.Id, false, validationResult));
        }
    }
}
