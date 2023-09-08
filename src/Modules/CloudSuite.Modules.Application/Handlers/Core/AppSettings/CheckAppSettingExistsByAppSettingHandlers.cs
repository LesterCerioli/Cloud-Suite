using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Responses;
using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests;
using CloudSuite.Modules.Application.Validations.Core.AppSettings;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings
{
  public class CheckAppSettingsExistsByAppSettingHandlers : IRequestHandler<CheckAppSettingExistsByAppSettingRequest, CheckAppSettingExistsByAppSettingResponse>
  {
    private IAppSettingRepository _appSettingRepository;
    private readonly ILogger<CheckAppSettingsExistsByAppSettingHandlers> _logger;
    public CheckAppSettingsExistsByAppSettingHandlers(IAppSettingRepository appSettingRepository, ILogger<CheckAppSettingsExistsByAppSettingHandlers> logger)
    {
      _appSettingRepository = appSettingRepository;
      _logger = logger;
    }

    public async Task<CheckAppSettingExistsByAppSettingResponse> Handle(CheckAppSettingExistsByAppSettingRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckAppSettingExistsByAppSettingRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckAppSettingExistsByAppSettingRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var appSetting = await _appSettingRepository.GetByAppSetting(request.Value);

          if (appSetting != null)
            return await Task.FromResult(new CheckAppSettingExistsByAppSettingResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckAppSettingExistsByAppSettingResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckAppSettingExistsByAppSettingResponse(request.Id, false, validationResult));
    }
  }
}