using CloudSuite.Modules.Application.Handlers.Core.States.Responses;
using StateEntity = CloudSuite.Modules.Domain.Models.Core.State;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.States
{
  public class CreateStateCommand : IRequest<CreateStateResponse>
  {
    public CreateStateCommand()
    {
      Id = Guid.NewGuid();
    }

    public StateEntity GetEntity()
    {
      return new StateEntity(
        this.Id,
        this.UF
      );
    }

    public Guid Id { get; private set; }
    public string? UF { get; private set; }
    public string? StateName { get; private set; }
  }
}