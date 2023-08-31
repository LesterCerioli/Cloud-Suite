using CloudSuite.Modules.Application.Handlers.Core.Users.Responses;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Users.Requests
{
  public class CheckUserExistsByEmailRequest : IRequest<CheckUserExistsByEmailResponse>
  {
    public Guid Id { get; private set; }

    public Email Email { get; private set; }
    
    public CheckUserExistsByEmailRequest(Email email)
    {
      Id = Guid.NewGuid();
      Email = email;
    }
  }
}