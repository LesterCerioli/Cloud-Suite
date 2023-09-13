using CloudSuite.Modules.Application.Handlers.Core.Countries.Responses;
using AddressEntity = CloudSuite.Modules.Domain.Models.Core.Country;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Countries
{
  public class CreateCountryCommand : IRequest<CreateCountryResponse>
  {
    public CreateCountryCommand()
    {
      Id = Guid.NewGuid();
    }

    public AddressEntity GetEntity()
    {
      return new AddressEntity(
          this.Id,
          this.CountryName,
          this.Code3,
          this.IsBillingEnabled,
          this.IsShippingEnabled,
          this.IsCityEnabled,
          this.IsZipCodeEnabled,
          this.IsDistrictEnabled
      );
    }

    public Guid Id { get; private set; }

    public string? CountryName { get; set; }

    public string? Code3 { get; set; }

    public bool? IsBillingEnabled { get; set; }

    public bool? IsShippingEnabled { get; set; }

    public bool? IsCityEnabled { get; set; } = true;

    public bool? IsZipCodeEnabled { get; set; } = true;

    public bool? IsDistrictEnabled { get; set; } = true;
  }
}