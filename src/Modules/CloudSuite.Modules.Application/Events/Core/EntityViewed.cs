using MediatR;

namespace CloudSuite.Modules.Application.Events.Core
{
    public class EntityViewed : INotification
    {
        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }
    }
}
