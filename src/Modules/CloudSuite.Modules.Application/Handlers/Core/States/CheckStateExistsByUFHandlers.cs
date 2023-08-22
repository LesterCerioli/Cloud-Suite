using CloudSuite.Modules.Application.Handlers.Core.States.Responses;
using CloudSuite.Modules.Application.Handlers.Core.States.Requests;
using CloudSuite.Modules.Application.Validations.Core.States;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.States
{
  public class CheckStateExistsByUFHandlers : IRequestHandler<CheckStateExistsByUFRequest, CheckStateExistsByUFResponse>
  {
    private IStateRepository _stateRepository;
    private readonly ILogger<CheckStateExistsByUFHandlers> _logger;
    public CheckStateExistsByUFHandlers(IStateRepository stateRepository, ILogger<CheckStateExistsByUFHandlers> logger)
    {
      _stateRepository = stateRepository;
      _logger = logger;
    }

    public async Task<CheckStateExistsByUFResponse> Handle(CheckStateExistsByUFRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckStateExistsByUFRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckStateExistsByUFRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var state = await _stateRepository.GetByUF(request.UF);

          if (state != null)
          return await Task.FromResult(new CheckStateExistsByUFResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckStateExistsByUFResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckStateExistsByUFResponse(request.Id, false, validationResult));
    }
  }
} 