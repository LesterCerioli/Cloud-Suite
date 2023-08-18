using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Responses;
using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Requests;
using CloudSuite.Modules.Application.Validations.Core.CustomerGroups;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.CustomerGroups
{
  public class CheckCustomerGroupExistsByNameHandlers : IRequestHandler<CheckCustomerGroupExistsByNameRequest, CheckCustomerGroupExistsByNameResponse>
  {
    private ICustomergroupRepository _customergroupRepository;
    private readonly ILogger<CheckCustomerGroupExistsByNameHandlers> _logger;
    public CheckCustomerGroupExistsByNameHandlers(ICustomergroupRepository customergroupRepository, ILogger<CheckCustomerGroupExistsByNameHandlers> logger)
    {
      _customergroupRepository = customergroupRepository;
      _logger = logger;
    }

    public async Task<CheckCustomerGroupExistsByNameResponse> Handle(CheckCustomerGroupExistsByNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckCustomerGroupExistsByNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckCustomerGroupExistsByNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var cutomerGroups = await _customergroupRepository.GetByName(request.Name);

          if (cutomerGroups != null)
          return await Task.FromResult(new CheckCustomerGroupExistsByNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckCustomerGroupExistsByNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckCustomerGroupExistsByNameResponse(request.Id, false, validationResult));
    }
  }
} 