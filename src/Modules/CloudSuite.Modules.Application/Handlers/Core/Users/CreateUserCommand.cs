using CloudSuite.Modules.Application.Handlers.Core.Users.Responses;
using UserEntity = CloudSuite.Modules.Domain.Models.Core.User;
using CloudSuite.Modules.Domain.ValueObjects;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Users
{
  public class CreateUserCommand : IRequest<CreateUserResponse>
  {
    public CreateUserCommand()
    {
      Id = Guid.NewGuid();
    }

    public UserEntity GetEntity()
    {
      return new UserEntity(
        this.FullName,
        this.Email,
        this.Cpf,
        this.Vendor,
        this.IsDeleted,
        this.CreatedOn,
        this.LatestUpdatedOn,
        this.RefreshTokenHash,
        this.Culture,
        this.ExtensionData
      );
    }

    public Guid Id { get; private set; }

    public string? FullName { get; private set; }

    public Email Email { get; private set; }

    public Cpf Cpf { get; private set; }

    public Vendor Vendor { get; private set; }

    public bool? IsDeleted { get; private set; }

    public DateTimeOffset? CreatedOn { get; private set; }

    public DateTimeOffset? LatestUpdatedOn { get; private set; }

    public string? RefreshTokenHash { get; private set; }

    public string? Culture { get; private set; }
    
    public string? ExtensionData { get; private set; }
  }
}