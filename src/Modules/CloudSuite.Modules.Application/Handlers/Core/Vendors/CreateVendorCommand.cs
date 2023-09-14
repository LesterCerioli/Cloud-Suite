using CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses;
using VendorEntity = CloudSuite.Modules.Domain.Models.Core.Vendor;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores
{
  public class CreateVendorCommand : IRequest<CreateVendorResponse>
  {
    public CreateVendorCommand()
    {
      Id = Guid.NewGuid();
    }

    public VendorEntity GetEntity()
    {
      return new VendorEntity(
        this.Id,
        this.Name,
        this.Slug,
        this.Description,
        this.Cnpj,
        this.Email,
        this.CreatedOn,
        this.LatestUpdatedOn,
        this.IsActive,
        this.IsDeleted
      );
    }

    public Guid Id { get; private set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Description { get; set; }

    public Cnpj Cnpj { get; set; }

    public Email Email { get; set; }

    public DateTimeOffset? CreatedOn { get; set; }

    public DateTimeOffset? LatestUpdatedOn { get; set; }

    public bool? IsActive { get; set; }
    
    public bool? IsDeleted { get; set; }
  }
}