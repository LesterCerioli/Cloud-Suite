using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class RoboEmail : Entity, IAggregateRoot
    {
        public RoboEmail(string? emailAddressSender, string? subject, string? body, DateTimeOffset? receivedTime, string? messageRecipient)
        {
            EmailAddressSender = emailAddressSender;
            Subject = subject;
            Body = body;
            ReceivedTime = receivedTime;
            MessageRecipient = messageRecipient;
        }

        public string? EmailAddressSender { get; private set; }        
        
        public string? Subject { get; private set; }

        public string? Body { get; private set; }

        //Data e hora de reebimento do email
        public DateTimeOffset? ReceivedTime { get; private set; }

        public string? MessageRecipient { get; private set; }
        
    }
}