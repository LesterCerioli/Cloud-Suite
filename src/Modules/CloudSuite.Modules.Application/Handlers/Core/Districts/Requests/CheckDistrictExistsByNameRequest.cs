using CloudSuite.Modules.Application.Handlers.Core.Districts.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Districts.Requests
{
  public class CheckDistrictExistsByNameRequest : IRequest<CheckDistrictExistsByNameResponse>
  {
    public Guid Id { get; private set; }

    public string? Name { get; private set; }
    
    public CheckDistrictExistsByNameRequest(string name)
    {
      Id = Guid.NewGuid();
      Name = name;
    }
  }
}