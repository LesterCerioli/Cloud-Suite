using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Responses;
using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Requests;
using CloudSuite.Modules.Application.Validations.Core.CustomerGroups;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.CustomerGroups
{
  public class CheckCustomerGroupExistsByLatestUpdatedOnHandlers : IRequestHandler<CheckCustomerGroupExistsByLatestUpdatedOnRequest, CheckCustomerGroupExistsByLatestUpdatedOnResponse>
  {
    private ICustomergroupRepository _customergroupRepository;
    private readonly ILogger<CheckCustomerGroupExistsByLatestUpdatedOnHandlers> _logger;
    public CheckCustomerGroupExistsByLatestUpdatedOnHandlers(ICustomergroupRepository customergroupRepository, ILogger<CheckCustomerGroupExistsByLatestUpdatedOnHandlers> logger)
    {
      _customergroupRepository = customergroupRepository;
      _logger = logger;
    }

    public async Task<CheckCustomerGroupExistsByLatestUpdatedOnResponse> Handle(CheckCustomerGroupExistsByLatestUpdatedOnRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckCustomerGroupExistsByLatestUpdatedOnRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckCustomerGroupExistsByLatestUpdatedOnRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var cutomerGroups = await _customergroupRepository.GetByLatestUpdatedOn(request.LatestUpdatedOn);

          if (cutomerGroups != null)
          return await Task.FromResult(new CheckCustomerGroupExistsByLatestUpdatedOnResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckCustomerGroupExistsByLatestUpdatedOnResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckCustomerGroupExistsByLatestUpdatedOnResponse(request.Id, false, validationResult));
    }
  }
} 