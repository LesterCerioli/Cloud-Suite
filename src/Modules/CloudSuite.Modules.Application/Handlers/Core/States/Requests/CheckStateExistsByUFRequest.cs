using CloudSuite.Modules.Application.Handlers.Core.States.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.States.Requests
{
  public class CheckStateExistsByUFRequest : IRequest<CheckStateExistsByUFResponse>
  {
    public Guid Id { get; private set; }
    public string? UF { get; private set; }
    public CheckStateExistsByUFRequest(string uf)
    {
      Id = Guid.NewGuid();
      UF = uf;
    }
  }
}