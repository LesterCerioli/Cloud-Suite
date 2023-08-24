using MediatR;

namespace CloudSuite.Modules.Application.Events.Core
{
    public class UserSignedIn : INotification
    {
        public long UserId { get; set; }
    }
}
