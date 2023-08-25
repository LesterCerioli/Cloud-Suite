using CloudSuite.Modules.Application.Handlers.Core.Medias.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias.Requests
{
  public class CheckMediaExistsByFileSizeRequest : IRequest<CheckMediaExistsByFileSizeResponse>
  {
    public Guid Id { get; private set; }

    public int? FileSize { get; set; }
    
    public CheckMediaExistsByFileSizeRequest(int? fileSize)
    {
      Id = Guid.NewGuid();
      FileSize = fileSize;
    }
  }
}