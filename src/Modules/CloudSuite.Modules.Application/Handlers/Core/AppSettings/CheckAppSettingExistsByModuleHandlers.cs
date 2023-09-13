using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Responses;
using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests;
using CloudSuite.Modules.Application.Validations.Core.AppSettings;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings
{
  public class CheckAppSettingsExistsByModuleHandlers : IRequestHandler<CheckAppSettingExistsByModuleRequest, CheckAppSettingExistsByModuleResponse>
  {
    private IAppSettingRepository _appSettingRepository;

    private readonly ILogger<CheckAppSettingsExistsByModuleHandlers> _logger;

    public CheckAppSettingsExistsByModuleHandlers(IAppSettingRepository appSettingRepository, ILogger<CheckAppSettingsExistsByModuleHandlers> logger)
    {
      _appSettingRepository = appSettingRepository;
      _logger = logger;
    }

    public async Task<CheckAppSettingExistsByModuleResponse> Handle(CheckAppSettingExistsByModuleRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckAppSettingExistsByModuleRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckAppSettingExistsByModuleRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var appSetting = await _appSettingRepository.GetByAppSetting(request.Module);

          if (appSetting != null)
            return await Task.FromResult(new CheckAppSettingExistsByModuleResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckAppSettingExistsByModuleResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      
      return await Task.FromResult(new CheckAppSettingExistsByModuleResponse(request.Id, false, validationResult));
    }
  }
}