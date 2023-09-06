using CloudSuite.Modules.Application.Handlers.Token.Responses;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Token.Requests
{
  public class SendTokenRequest : IRequest<SendTokenReponse>
  {
    public SendTokenRequest(Guid id, string? fullName, Telephone telephone)
    {
      Id = id;
      FullName = fullName;
      Telephone = telephone;

    }

    public Guid Id { get; private set; }

    public string? FullName { get; set; }

    public Telephone Telephone { get; set; }
  }
}