using CloudSuite.Modules.Application.Handlers.Core.Medias.Responses;
using MediaEntity = CloudSuite.Modules.Domain.Models.Core.Media;
using MediatR;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias
{
    public class CreateMediaCommand : IRequest<CreateMediaResponse>
    {
        public CreateMediaCommand()
        {
            Id = Guid.NewGuid();
        }

        public MediaEntity GetEntity()
        {
            return new MediaEntity(
                this.Id,
                this.Caption,
                this.FileSize,
                this.FileName,
                this.MediaType
            );
        }

        public Guid Id { get; private set; }
        public string? Caption { get; set; }
        public int? FileSize { get; set; }
        public string? FileName { get; set; }
        public MediaType MediaType { get; set; }
    }
}