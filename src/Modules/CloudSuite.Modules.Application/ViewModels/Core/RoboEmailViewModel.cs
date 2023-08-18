namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class RoboEmailViewModel
    {
        public long Id { get; set; }

        public string EmailAddressSender { get; private set; }        
        
        public string Subject { get; private set; }

        public string Body { get; private set; }

        //Data e hora de reebimento do email
        public DateTimeOffset ReceivedTime { get; private set; }

        public string MessageRecipient { get; private set; }
    }
}