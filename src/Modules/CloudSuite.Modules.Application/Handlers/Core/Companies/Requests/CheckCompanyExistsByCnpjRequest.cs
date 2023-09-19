using CloudSuite.Modules.Application.Handlers.Core.Companies.Responses;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies.Requests
{
    public class CheckCompanyExistsByCnpjRequest : IRequest<CheckCompanyExistsByCnpjResponse>
    {
        public Guid Id { get; private set; }

        public Cnpj Cnpj { get; set; }

        public CheckCompanyExistsByCnpjRequest(Cnpj cnpj)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
        }
    }
}