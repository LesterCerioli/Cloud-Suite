using CloudSuite.Modules.Application.Handlers.Core.Companies.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using CloudSuite.Modules.Application.Validations.Core.Companies;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies
{
    public class CheckCompanyExistsByCnpjHandlers : IRequestHandler<CheckCompanyExistsByCnpjRequest, CheckCompanyExistsByCnpjResponse>
    {
        private ICompanyRepository _companyRepository;

        private readonly ILogger<CheckCompanyExistsByCnpjHandlers> _logger;

        public CheckCompanyExistsByCnpjHandlers(ICompanyRepository companyRepository, ILogger<CheckCompanyExistsByCnpjHandlers> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public async Task<CheckCompanyExistsByCnpjResponse> Handle(CheckCompanyExistsByCnpjRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCompanyExistsByCnpjRequest: {JsonSerializer.Serialize(request)}");

            var validationResult = new CheckCompanyExistsByCnpjRequestValidation().Validate(request);
            
            if (validationResult.IsValid)
            {
                try
                {
                    var company = await _companyRepository.GetByCnpj(request.Cnpj);

                    if (company != null)
                        return await Task.FromResult(new CheckCompanyExistsByCnpjResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCompanyExistsByCnpjResponse(request.Id, "Não foi possivel processar a solicitação"));
                }
            }

            return await Task.FromResult(new CheckCompanyExistsByCnpjResponse(request.Id, false, validationResult));
        }
    }
}