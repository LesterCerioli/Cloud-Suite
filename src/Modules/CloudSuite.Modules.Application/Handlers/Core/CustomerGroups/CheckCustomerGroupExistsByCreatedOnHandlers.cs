using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Responses;
using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Requests;
using CloudSuite.Modules.Application.Validations.Core.CustomerGroups;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.CustomerGroups
{
  public class CheckCustomerGroupExistsByCreatedOnHandlers : IRequestHandler<CheckCustomerGroupExistsByCreatedOnRequest, CheckCustomerGroupExistsByCreatedOnResponse>
  {
    private ICustomergroupRepository _customergroupRepository;
    private readonly ILogger<CheckCustomerGroupExistsByCreatedOnHandlers> _logger;
    public CheckCustomerGroupExistsByCreatedOnHandlers(ICustomergroupRepository customergroupRepository, ILogger<CheckCustomerGroupExistsByCreatedOnHandlers> logger)
    {
      _customergroupRepository = customergroupRepository;
      _logger = logger;
    }

    public async Task<CheckCustomerGroupExistsByCreatedOnResponse> Handle(CheckCustomerGroupExistsByCreatedOnRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckCustomerGroupExistsByCreatedOnRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckCustomerGroupExistsByCreatedOnRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var cutomerGroups = await _customergroupRepository.GetByCreatedOn(request.CreatedOn);

          if (cutomerGroups != null)
          return await Task.FromResult(new CheckCustomerGroupExistsByCreatedOnResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckCustomerGroupExistsByCreatedOnResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckCustomerGroupExistsByCreatedOnResponse(request.Id, false, validationResult));
    }
  }
} 