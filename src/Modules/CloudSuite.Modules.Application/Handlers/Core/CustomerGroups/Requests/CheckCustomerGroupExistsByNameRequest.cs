using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Requests
{
    public class CheckCustomerGroupExistsByNameRequest : IRequest<CheckCustomerGroupExistsByNameResponse>
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public CheckCustomerGroupExistsByNameRequest(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
