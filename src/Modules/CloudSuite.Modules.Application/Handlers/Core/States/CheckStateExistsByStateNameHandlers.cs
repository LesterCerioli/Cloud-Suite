using CloudSuite.Modules.Application.Handlers.Core.States.Responses;
using CloudSuite.Modules.Application.Handlers.Core.States.Requests;
using CloudSuite.Modules.Application.Validations.Core.States;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.States
{
  public class CheckStateExistsByStateNameHandlers : IRequestHandler<CheckStateExistsByStateNameRequest, CheckStateExistsByStateNameResponse>
  {
    private IStateRepository _stateRepository;
    private readonly ILogger<CheckStateExistsByStateNameHandlers> _logger;
    public CheckStateExistsByStateNameHandlers(IStateRepository stateRepository, ILogger<CheckStateExistsByStateNameHandlers> logger)
    {
      _stateRepository = stateRepository;
      _logger = logger;
    }

    public async Task<CheckStateExistsByStateNameResponse> Handle(CheckStateExistsByStateNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckStateExistsByStateNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckStateExistsByStateNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var state = await _stateRepository.GetByName(request.StateName);

          if (state != null)
            return await Task.FromResult(new CheckStateExistsByStateNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckStateExistsByStateNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckStateExistsByStateNameResponse(request.Id, false, validationResult));
    }
  }
}