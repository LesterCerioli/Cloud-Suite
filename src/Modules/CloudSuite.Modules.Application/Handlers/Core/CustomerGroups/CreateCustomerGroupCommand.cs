using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Responses;
using CustomerGroupEntity = CloudSuite.Modules.Domain.Models.Core.CustomerGroup;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.CustomerGroups
{
  public class CreateCustomerGroupCommand : IRequest<CreateCustomerGroupResponse>
  {
    public CreateCustomerGroupCommand()
    {
        Id = Guid.NewGuid();
    }

    public CustomerGroupEntity GetEntity()
    {
        return new CustomerGroupEntity(
            this.Name,
            this.Description,
            this.IsActive,
            this.IsDeleted,
            this.CreatedOn,
            this.LatestUpdatedOn
        );
    }

    public Guid Id { get; private set; }
    public string? Name { get; private set; }

    public string? Description { get; private set; }

    public bool? IsActive { get; private set; }

    public bool? IsDeleted { get; private set; }

    public DateTimeOffset? CreatedOn { get; private set; }

    public DateTimeOffset? LatestUpdatedOn { get; private set; }
  }
}