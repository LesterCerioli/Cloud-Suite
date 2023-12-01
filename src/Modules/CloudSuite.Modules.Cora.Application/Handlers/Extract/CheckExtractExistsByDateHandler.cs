using CloudSuite.Modules.Cora.Application.Handlers.Extract.Request;
using CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Extract;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extract
{
    public class CheckExtractExistsByDateHandler : IRequestHandler<CheckExtractExistsByDateRequest, CheckExtractExistsByDateResponse>
    {
        private IExtractRepository _extractRepository;
        private readonly ILogger<CheckExtractExistsByDateHandler> _logger;

        public CheckExtractExistsByDateHandler(IExtractRepository extractRepository, ILogger<CheckExtractExistsByDateHandler> logger)
        {
            _extractRepository = extractRepository;
            _logger = logger;
        }

        public async Task<CheckExtractExistsByDateResponse> Handle(CheckExtractExistsByDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckExtractExistsByDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var extractStartDate = await _extractRepository.GetByStartDate(request.StartDate);
                    var extractEndDate = await _extractRepository.GetByStartDate(request.EndDate);

                    if(extractStartDate != null && extractEndDate != null)
                    {
                        return await Task.FromResult(new CheckExtractExistsByDateResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckExtractExistsByDateResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckExtractExistsByDateResponse(request.Id, false, validationResult));
        }
    }
}



