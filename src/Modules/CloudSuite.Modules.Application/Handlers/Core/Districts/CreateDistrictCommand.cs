using CloudSuite.Modules.Application.Handlers.Core.Districts.Responses;
using DistrictEntity = CloudSuite.Modules.Domain.Models.Core.District;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Districts
{
  public class CreateDistrictCommand : IRequest<CreateDistrictResponse>
  {

    public CreateDistrictCommand()
    {
      Id = Guid.NewGuid();
    }

    public DistrictEntity GetEntity()
    {
      return new DistrictEntity(
          this.Id,
          this.Name,
          this.Type,
          this.Location
      );
    }

    public Guid Id { get; private set; }

    public string? Name { get; private set; }

    public string? Type { get; private set; }

    public string? Location { get; private set; }
  }
}