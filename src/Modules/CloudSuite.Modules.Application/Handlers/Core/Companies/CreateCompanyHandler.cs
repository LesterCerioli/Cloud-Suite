using CloudSuite.Modules.Application.Handlers.Core.Companies.Responses;
using CloudSuite.Modules.Application.Validations.Core.Companies;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies
{
  public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyResponse>
  {
    private ICompanyRepository _companyRepository;
    private readonly ILogger<CreateCompanyHandler> _logger;
    public CreateCompanyHandler(ICompanyRepository companyRepository, ILogger<CreateCompanyHandler> logger)
    {
      _companyRepository = companyRepository;
      _logger = logger;
    }
    public async Task<CreateCompanyResponse> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateCompanyCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateCompanyCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var companies = await _companyRepository.GetByFantasyName(command.FantasyName);

          if (companies != null)
            return await Task.FromResult(new CreateCompanyResponse(command.Id, "Cidade já cadastrada."));

          await _companyRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateCompanyResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateCompanyResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }

      return await Task.FromResult(new CreateCompanyResponse(command.Id, validationResult));
    }
  }
}