using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Requests
{
    public class CheckCustomerGroupExistsByCreatedOnRequest : IRequest<CheckCustomerGroupExistsByCreatedOnResponse>
    {
        public Guid Id { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public CheckCustomerGroupExistsByCreatedOnRequest(DateTimeOffset createdOn)
        {
            Id = Guid.NewGuid();
            CreatedOn = createdOn;
        }
    }
}
