using CloudSuite.Modules.Application.Handlers.Token.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Token.Requests
{
  public class SendTokenRequest : IRequest<SendTokenReponse>
  {
        public SendTokenRequest(Guid id, string? fullName, string? telephoneRegion, string? telephoneNumber)
        {
            Id = id;
            FullName = fullName;
            TelephoneRegion = telephoneRegion;
            TelephoneNumber = telephoneNumber;
        }

        public Guid Id { get; private set; }

        public string? FullName { get; set; }

        public string? TelephoneRegion { get; set; }
    
        public string? TelephoneNumber { get; set; }

    
  }
}