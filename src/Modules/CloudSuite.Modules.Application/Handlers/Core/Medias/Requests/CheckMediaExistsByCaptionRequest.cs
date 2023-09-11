using CloudSuite.Modules.Application.Handlers.Core.Medias.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias.Requests
{
  public class CheckMediaExistsByCaptionRequest : IRequest<CheckMediaExistsByCaptionResponse>
  {
    public Guid Id { get; private set; }

    public string? Caption { get; set; }
    
    public CheckMediaExistsByCaptionRequest(string? caption)
    {
      Id = Guid.NewGuid();
      Caption = caption;
    }
  }
}