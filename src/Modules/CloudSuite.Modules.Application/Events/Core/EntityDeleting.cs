using MediatR;

namespace CloudSuite.Modules.Application.Events.Core
{
    public class EntityDeleting : INotification
    {
        public long EntityId { get; set; }
    }
}
