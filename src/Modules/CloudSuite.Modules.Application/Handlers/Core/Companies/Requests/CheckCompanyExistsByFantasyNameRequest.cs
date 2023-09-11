using CloudSuite.Modules.Application.Handlers.Core.Companies.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies.Requests
{
  public class CheckCompanyExistsByFantasyNameRequest : IRequest<CheckCompanyExistsByFantasyNameResponse>
  {
    public Guid Id { get; private set; }

    public string? FantasyName { get; set; }

    public CheckCompanyExistsByFantasyNameRequest(string fantasyName)
    {
      Id = Guid.NewGuid();
      FantasyName = fantasyName;
    }
  }
}