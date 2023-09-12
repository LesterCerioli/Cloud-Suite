using CloudSuite.Modules.Application.Handlers.Core.Countries.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Countries.Requests
{
  public class CheckCountryExistsByCodeRequest : IRequest<CheckCountryExistsByCodeResponse>
  {
    public Guid Id { get; private set; }

    public string? Code3 { get; private set; }
    
    public CheckCountryExistsByCodeRequest(string code3)
    {
      Id = Guid.NewGuid();
      Code3 = code3;
    }
  }
}
