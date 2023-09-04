using CloudSuite.Modules.Application.Handlers.Token.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Token.Requests
{
  public class SendTokenRequest : IRequest<SendTokenReponse>
  {
    public Guid Id { get; private set; }

    public string? FullName { get; set; }

    public string? PhoneRegion { get; set; }
    
    public string? PhoneNumber { get; set; }

    public SendTokenRequest(string fullName, string phoneRegion, string phoneNumber)
    {
      Id = Guid.NewGuid();
      FullName = fullName;
      PhoneRegion = phoneRegion;
      PhoneNumber = phoneNumber;
    }
  }
}