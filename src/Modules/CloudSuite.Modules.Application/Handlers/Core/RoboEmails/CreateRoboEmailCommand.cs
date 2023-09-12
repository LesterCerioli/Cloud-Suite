using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses;
using RoboEmailEntity = CloudSuite.Modules.Domain.Models.Core.RoboEmail;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails
{
  public class CreateRoboEmailCommand : IRequest<CreateRoboEmailResponse>
  {
    public CreateRoboEmailCommand()
    {
      Id = Guid.NewGuid();
    }

    public RoboEmailEntity GetEntity()
    {
      return new RoboEmailEntity(
        this.EmailAddressSender,
        this.Subject,
        this.Body,
        this.ReceivedTime,
        this.MessageRecipient
      );
    }

    public Guid Id { get; private set; }

    public string? EmailAddressSender { get; private set; }

    public string? Subject { get; private set; }

    public string? Body { get; private set; }

    public DateTimeOffset? ReceivedTime { get; private set; }
    
    public string? MessageRecipient { get; private set; }
  }
}