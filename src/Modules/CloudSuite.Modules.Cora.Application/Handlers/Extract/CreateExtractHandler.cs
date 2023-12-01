using CloudSuite.Modules.Cora.Application.Handlers.Extrato.Responses;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using CloudSuite.Modules.Cora.Application.Validation.Extract;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extrato
{
    public class CreateExtractHandler : IRequestHandler<CreateExtractCommand, CreateExtractResponse>
    {
        private readonly IExtractRepository _extractRepository;
        private readonly ILogger<CreateExtractHandler> _logger;

        public CreateExtractHandler(IExtractRepository extractRepository, ILogger<CreateExtractHandler> logger)
        {
            _extractRepository = extractRepository;
            _logger = logger;
        }

        public async Task<CreateExtractResponse> Handle(CreateExtractCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateExtractCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateExtractCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var extractStartDateExists = await _extractRepository.GetByStartDate(command.StartDate);
                    var extractEndDateExists = await _extractRepository.GetByEndDate(command.EndDate);
                    var extractCustomerExists = await _extractRepository.GetByCustomer(command.Customer);

                    if (extractStartDateExists == null && extractEndDateExists == null && extractCustomerExists == null)
                    {
                        await _extractRepository.Add(command.GetEntity());
                        return new CreateExtractResponse(command.Id, validationResult);

                    }

                    return new CreateExtractResponse(command.Id, "Extract already registered");

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating extract");
                    return new CreateExtractResponse(command.Id, "Error creating extract");
                }
            }
            else
            {
                return new CreateExtractResponse(command.Id, validationResult);
            }
        }
    }
}


