using TokenEntity = CloudSuite.Modules.Domain.Models.Token.RequestToken;
using CloudSuite.Modules.Application.Handlers.Token.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Token
{
  public class CreateTokenCommand : IRequest<CreateTokenResponse>
  {
    public CreateTokenCommand()
    {
      Id = Guid.NewGuid();
    }

    public TokenEntity GetEntity()
    {
      return new TokenEntity(
        this.Id,
        this.FullName,
        this.PhoneRegion,
        this.PhoneNumber,
        this.Created
      );
    }

    public Guid Id { get; private set; }

    public string FullName { get; set; }

    public string PhoneRegion { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Validated { get; set; }

    public string Token { get; set; }
  }
}