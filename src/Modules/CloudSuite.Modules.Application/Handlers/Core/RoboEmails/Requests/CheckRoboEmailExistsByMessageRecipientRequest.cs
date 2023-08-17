using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests
{
    public class CheckRoboEmailExistsByMessageRecipientRequest : IRequest<CheckRoboEmailExistsByMessageRecipientResponse>
    {
        public Guid Id { get; private set; }
        public string? MessageRecipient { get; private set; }
        public CheckRoboEmailExistsByMessageRecipientRequest(string messageRecipient)
        {
            Id = Guid.NewGuid();
            MessageRecipient = messageRecipient;
        }
    }
}