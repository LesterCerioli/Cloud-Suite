using CloudSuite.Modules.Application.Handlers.Core.Medias.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias.Requests
{
    public class CheckMediaExistsByFileNameRequest : IRequest<CheckMediaExistsByFileNameResponse>
    {
        public Guid Id { get; private set; }
        public string? FileName { get; set; }
        public CheckMediaExistsByFileNameRequest(string? name)
        {
            Id = Guid.NewGuid();
            FileName = name;
        }
    }
}