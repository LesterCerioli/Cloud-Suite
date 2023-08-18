using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Requests
{
    public class CheckCustomerGroupExistsByLatestUpdatedOnRequest : IRequest<CheckCustomerGroupExistsByLatestUpdatedOnResponse>
    {
        public Guid Id { get; private set; }
        public DateTimeOffset LatestUpdatedOn { get; private set; }
        public CheckCustomerGroupExistsByLatestUpdatedOnRequest(DateTimeOffset latestUpdatedOn)
        {
            Id = Guid.NewGuid();
            LatestUpdatedOn = latestUpdatedOn;
        }
    }
}
