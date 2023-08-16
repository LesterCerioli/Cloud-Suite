using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests
{
    public class CheckRoboEmailExistsByReceivedTimeRequest : IRequest<CheckRoboEmailExistsByReceivedTimeResponse>
    {
        public Guid Id { get; private set; }
        public DateTimeOffset ReceivedTime { get; private set; }
        public CheckRoboEmailExistsByReceivedTimeRequest(DateTimeOffset receivedTime)
        {
            Id = Guid.NewGuid();
            ReceivedTime = receivedTime;
        }
    }
}