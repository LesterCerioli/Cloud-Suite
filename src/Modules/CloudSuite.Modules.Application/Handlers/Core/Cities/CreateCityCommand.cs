using CloudSuite.Modules.Application.Handlers.Core.Cities.Responses;
using CityEntity = CloudSuite.Modules.Domain.Models.Core.City;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Cities
{
  public class CreateCityCommand : IRequest<CreateCityResponse>
  {
    public Guid Id { get; private set; }

    public string? CityName { get; private set; }
    public State State { get; private set; }

    public CreateCityCommand()
    {
      Id = Guid.NewGuid();
    }

    public CityEntity GetEntity()
    {
      return new CityEntity(this.Id);
    }
  }
}