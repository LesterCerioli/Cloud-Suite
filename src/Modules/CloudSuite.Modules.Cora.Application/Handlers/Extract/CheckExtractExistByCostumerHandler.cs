using CloudSuite.Modules.Cora.Application.Handlers.Extract.Request;
using CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Extract;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;


namespace CloudSuite.Modules.Cora.Application.Handlers.Extract
{
    public class CheckExtractExistByCostumerHandler : IRequestHandler<CheckExtractExistByCostumerRequest, CheckExtractExistByCostumerResponse>
    {
        private IExtractRepository _extractRepository;
        private readonly ILogger<CheckExtractExistByCostumerHandler> _logger;

        public CheckExtractExistByCostumerHandler(IExtractRepository extractRepository, ILogger<CheckExtractExistByCostumerHandler> logger)
        {
            _extractRepository = extractRepository;
            _logger = logger;
        }

        public async Task<CheckExtractExistByCostumerResponse> Handle(CheckExtractExistByCostumerRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistByCostumerRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckExtractExistByCostumerRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var extractStartDate = await _extractRepository.GetByCustomer(request.Customer);

                    if (extractStartDate != null)
                    {
                        return await Task.FromResult(new CheckExtractExistByCostumerResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckExtractExistByCostumerResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckExtractExistByCostumerResponse(request.Id, false, validationResult));
        }
    }
}



