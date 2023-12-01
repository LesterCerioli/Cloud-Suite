using CloudSuite.Infrastructure.Data.Repositories.Cora;
using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Transaction;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;
namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, CreateTransactionResponse>
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly ILogger<CreateTransactionHandler> _logger;

        public CreateTransactionHandler(TransactionRepository transactionRepository, ILogger<CreateTransactionHandler> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<CreateTransactionResponse> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateTransactionCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateTransactionCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var transactionCounterPartyNameExists = await _transactionRepository.GetByCounterPartyName(command.EntryTransactionCounterPartyName);
                    var transactionTransactionOrderExists = await _transactionRepository.GetByTransactionOrder(command.TransactiOnorder);


                    if (transactionCounterPartyNameExists == null && transactionTransactionOrderExists == null)
                    {
                        await _transactionRepository.Add(command.GetEntity());

                        return new CreateTransactionResponse(command.Id, validationResult);

                    }

                    return new CreateTransactionResponse(command.Id, "Transaction already exists.");

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to process the request");
                    return new CreateTransactionResponse(command.Id, "Failed to process the request.");
                }
            }
            else
            {
                return new CreateTransactionResponse(command.Id, validationResult);
            }
        }
    }
}