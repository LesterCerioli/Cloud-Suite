using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Responses;
using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests;
using CloudSuite.Modules.Application.Validations.Core.AppSettings;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings
{
  public class CheckAppSettingExistsByValueHandlers : IRequestHandler<CheckAppSettingExistsByValueRequest, CheckAppSettingExistsByValueResponse>
  {
    private IAppSettingRepository _appSettingRepository;

    private readonly ILogger<CheckAppSettingExistsByValueHandlers> _logger;

    public CheckAppSettingExistsByValueHandlers(IAppSettingRepository appSettingRepository, ILogger<CheckAppSettingExistsByValueHandlers> logger)
    {
      _appSettingRepository = appSettingRepository;
      _logger = logger;
    }

    public async Task<CheckAppSettingExistsByValueResponse> Handle(CheckAppSettingExistsByValueRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckAppSettingExistsByValueRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckAppSettingExistsByValueRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var appSetting = await _appSettingRepository.GetByValue(request.Value);

          if (appSetting != null)
            return await Task.FromResult(new CheckAppSettingExistsByValueResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckAppSettingExistsByValueResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      
      return await Task.FromResult(new CheckAppSettingExistsByValueResponse(request.Id, false, validationResult));
    }
  }
}