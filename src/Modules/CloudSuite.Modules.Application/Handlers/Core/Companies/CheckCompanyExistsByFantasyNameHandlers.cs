using CloudSuite.Modules.Application.Handlers.Core.Companies.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using CloudSuite.Modules.Application.Validations.Core.Companies;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies
{
  public class CheckCompanyExistsByFantasyNameHandlers : IRequestHandler<CheckCompanyExistsByFantasyNameRequest, CheckCompanyExistsByFantasyNameResponse>
  {
    private ICompanyRepository _companyRepository;

    private readonly ILogger<CheckCompanyExistsByFantasyNameHandlers> _logger;

    public CheckCompanyExistsByFantasyNameHandlers(ICompanyRepository companyRepository, ILogger<CheckCompanyExistsByFantasyNameHandlers> logger)
    {
      _companyRepository = companyRepository;
      _logger = logger;
    }

    public async Task<CheckCompanyExistsByFantasyNameResponse> Handle(CheckCompanyExistsByFantasyNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckCompanyExistsByFantasyNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckCompanyExistsByFantasyNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var company = await _companyRepository.GetByFantasyName(request.FantasyName);

          if (company != null)
            return await Task.FromResult(new CheckCompanyExistsByFantasyNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckCompanyExistsByFantasyNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      
      return await Task.FromResult(new CheckCompanyExistsByFantasyNameResponse(request.Id, false, validationResult));
    }
  }
}