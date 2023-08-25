using CloudSuite.Modules.Application.Handlers.Core.States.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.States.Requests
{
  public class CheckStateExistsByStateNameRequest : IRequest<CheckStateExistsByStateNameResponse>
  {
    public Guid Id { get; private set; }

    public string? StateName { get; private set; }
    
    public CheckStateExistsByStateNameRequest(string stateName)
    {
      Id = Guid.NewGuid();
      StateName = stateName;
    }
  }
}