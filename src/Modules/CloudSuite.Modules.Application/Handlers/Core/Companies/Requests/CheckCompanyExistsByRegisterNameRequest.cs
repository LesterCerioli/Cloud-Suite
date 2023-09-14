using CloudSuite.Modules.Application.Handlers.Core.Companies.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies.Requests
{
  public class CheckCompanyExistsByRegisterNameRequest : IRequest<CheckCompanyExistsByRegisterNameResponse>
  {
    public Guid Id { get; private set; }

    public string? RegisterName { get; set; }

    public CheckCompanyExistsByRegisterNameRequest(string registerName)
    {
      Id = Guid.NewGuid();
      RegisterName = registerName;
    }
  }
}