using CloudSuite.Modules.Application.Handlers.Core.Districts.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Districts.Requests;
using CloudSuite.Modules.Application.Validations.Core.District;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Districts
{
  public class CheckDistrictExistsByNameHandlers : IRequestHandler<CheckDistrictExistsByNameRequest, CheckDistrictExistsByNameResponse>
  {
    private IDistrictRepository _districtRepository;
    private readonly ILogger<CheckDistrictExistsByNameHandlers> _logger;
    public CheckDistrictExistsByNameHandlers(IDistrictRepository districtRepository, ILogger<CheckDistrictExistsByNameHandlers> logger)
    {
      _districtRepository = districtRepository;
      _logger = logger;
    }

    public async Task<CheckDistrictExistsByNameResponse> Handle(CheckDistrictExistsByNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckDistrictExistsByNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckDistrictExistsByNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var district = await _districtRepository.GetByName(request.Name);

          if (district != null)
            return await Task.FromResult(new CheckDistrictExistsByNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckDistrictExistsByNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckDistrictExistsByNameResponse(request.Id, false, validationResult));
    }
  }
}