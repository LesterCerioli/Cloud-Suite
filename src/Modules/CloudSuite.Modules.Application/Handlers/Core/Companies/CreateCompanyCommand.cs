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

    public Guid CnpjId { get; private set; }

    public string? FantasyName { get; private set; }

    public string? RegisterName { get; private set; }

    public Address Address { get; private set; }

    public Guid AddressId { get; private set; }
  }
}