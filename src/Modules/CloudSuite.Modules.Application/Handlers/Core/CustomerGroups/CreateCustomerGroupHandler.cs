using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Responses;
using CloudSuite.Modules.Application.Validations.Core.CustomerGroups;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.CustomerGroups
{
  public class CreateCustomerGroupHandler : IRequestHandler<CreateCustomerGroupCommand, CreateCustomerGroupResponse>
  {
    private ICustomergroupRepository _customergroupRepository;
    private readonly ILogger<CreateCustomerGroupHandler> _logger;
    public CreateCustomerGroupHandler(ICustomergroupRepository customergroupRepository, ILogger<CreateCustomerGroupHandler> logger)
    {
      _customergroupRepository = customergroupRepository;
      _logger = logger;
    }

    public async Task<CreateCustomerGroupResponse> Handle(CreateCustomerGroupCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateCustomerGroupCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateCustomerGroupCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var customerGroups = await _customergroupRepository.GetByName(command.Name);

          if (customerGroups != null)
          return await Task.FromResult(new CreateCustomerGroupResponse(command.Id, "País já cadastrado"));

          await _customergroupRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateCustomerGroupResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateCustomerGroupResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateCustomerGroupResponse(command.Id, validationResult));
    }
  }
}