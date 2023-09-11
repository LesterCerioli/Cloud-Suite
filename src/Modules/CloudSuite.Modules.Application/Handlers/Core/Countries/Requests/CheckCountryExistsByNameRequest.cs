using CloudSuite.Modules.Application.Handlers.Core.Countries.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Countries.Requests
{
  public class CheckCountryExistsByNameRequest : IRequest<CheckCountryExistsByNameResponse>
  {
    public Guid Id { get; private set; }

    public string? CountryName { get; set; }
    
    public CheckCountryExistsByNameRequest(string countryName)
    {
      Id = Guid.NewGuid();
      CountryName = countryName;
    }
  }
}
