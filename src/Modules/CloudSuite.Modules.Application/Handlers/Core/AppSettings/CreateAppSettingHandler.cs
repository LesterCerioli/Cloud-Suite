using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Responses;
using CloudSuite.Modules.Application.Validations.Core.AppSettings;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings
{
  public class CreateAppSettingHandler : IRequestHandler<CreateAppSettingCommand, CreateAppSettingResponse>
  {
    private IAppSettingRepository _appSettingRepository;
    private readonly ILogger<CreateAppSettingHandler> _logger;
    public CreateAppSettingHandler(IAppSettingRepository appSettingRepository, ILogger<CreateAppSettingHandler> logger)
    {
      _appSettingRepository = appSettingRepository;
      _logger = logger;
    }

    public async Task<CreateAppSettingResponse> Handle(CreateAppSettingCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateAppSettingCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateAppSettingCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var appSettings = await _appSettingRepository.GetByValue(command.Value);

          if (appSettings != null)
            return await Task.FromResult(new CreateAppSettingResponse(command.Id, "Endereço já cadastrado"));

          await _appSettingRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateAppSettingResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateAppSettingResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }

      return await Task.FromResult(new CreateAppSettingResponse(command.Id, validationResult));
    }
  }
}