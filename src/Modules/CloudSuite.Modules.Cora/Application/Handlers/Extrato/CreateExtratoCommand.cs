using CloudSuite.Modules.Application.Handlers.Cora.Extrato.Responses;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato.Responses;
using MediatR;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extrato
{
    public class CreateExtratoCommand : IRequest<CreateExtratoResponse>
    {

        public CreateExtratoCommand()
        {
            Id = Guid.NewGuid();
        }

        public ExtratoEntity GetEntity()
        {
            return new ExtratoEntity(
              this.Id,
              this.Start,
              this.End,
              this.Type,
              this.TransactionType,
              this.Page,
              this.PerPage,
              this.Aggr
            );
        }

        public Guid Id { get; private set; }

        public string? Start { get; set; }

        public string? End { get; set; }

        public string? Type { get; set; }

        public string? TransactionType { get; set; }

        public int? Page { get; set; }

        public int? PerPage { get; set; }

        public bool? Aggr { get; set; }
    }
}