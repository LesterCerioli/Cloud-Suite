using CloudSuite.Modules.Application.Handlers.Core.Users.Responses;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Users.Requests
{
  public class CheckUserExistsByCpfRequest : IRequest<CheckUserExistsByCpfResponse>
  {
    public Guid Id { get; private set; }
    public Cpf Cpf { get; private set; }
    public CheckUserExistsByCpfRequest(Cpf cpf)
    {
      Id = Guid.NewGuid();
      Cpf = cpf;
    }
  }
}