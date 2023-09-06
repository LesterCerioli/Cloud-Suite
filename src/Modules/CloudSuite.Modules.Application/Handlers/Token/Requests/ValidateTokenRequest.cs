using CloudSuite.Modules.Application.Handlers.Token.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Token.Requests
{
  public class ValidateTokenRequest : IRequest<ValidateTokenResponse>
  {
    public Guid Id { get; private set; }

    public string? RequestId { get; set; }

    public string? Token { get; set; }

    public ValidateTokenRequest(string requestId, string token)
    {
      Id = Guid.NewGuid();
      RequestId = requestId;
      Token = token;
    }
  }
}