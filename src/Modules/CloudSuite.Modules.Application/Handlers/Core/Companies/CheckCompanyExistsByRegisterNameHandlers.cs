using CloudSuite.Modules.Application.Handlers.Core.Companies.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using CloudSuite.Modules.Application.Validations.Core.Companies;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies
{
  public class CheckCompanyExistsByRegisterNameHandlers : IRequestHandler<CheckCompanyExistsByRegisterNameRequest, CheckCompanyExistsByRegisterNameResponse>
  {
    private ICompanyRepository _companyRepository;

    private readonly ILogger<CheckCompanyExistsByRegisterNameHandlers> _logger;

    public CheckCompanyExistsByRegisterNameHandlers(ICompanyRepository companyRepository, ILogger<CheckCompanyExistsByRegisterNameHandlers> logger)
    {
      _companyRepository = companyRepository;
      _logger = logger;
    }

    public async Task<CheckCompanyExistsByRegisterNameResponse> Handle(CheckCompanyExistsByRegisterNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckCompanyExistsByRegisterNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckCompanyExistsByRegisterNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var company = await _companyRepository.GetByFantasyName(request.RegisterName);

          if (company != null)
            return await Task.FromResult(new CheckCompanyExistsByRegisterNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckCompanyExistsByRegisterNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      
      return await Task.FromResult(new CheckCompanyExistsByRegisterNameResponse(request.Id, false, validationResult));
    }
  }
}