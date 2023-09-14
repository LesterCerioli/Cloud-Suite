using CloudSuite.Modules.Application.Handlers.Core.Companies.Responses;
using CompanyEntity = CloudSuite.Modules.Domain.Models.Core.Company;
using CloudSuite.Modules.Domain.ValueObjects;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies
{
  public class CreateCompanyCommand : IRequest<CreateCompanyResponse>
  {
    public CreateCompanyCommand()
    {
      Id = Guid.NewGuid();
    }

    public CompanyEntity GetEntity()
    {
      return new CompanyEntity(
        this.Id,
        this.Cnpj,
        this.FantasyName,
        this.RegisterName,
        this.Address
      );
    }

    public Guid Id { get; private set; }

    public Cnpj Cnpj { get; set; }

    public string? FantasyName { get; set; }

    public string? RegisterName { get; set; }

    public Address Address { get; set; }
  }
}