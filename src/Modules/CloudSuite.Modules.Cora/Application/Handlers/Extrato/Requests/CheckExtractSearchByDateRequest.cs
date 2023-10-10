using CloudSuite.Modules.Cora.Application.Handlers.Extrato.Responses;
using MediatR;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extrato.Requests
{
    public class CheckExtractSearchByDateRequest : IRequest<CheckExtractSearchByDateResponse>
    {
        public Guid Id { get; private set; }

        public string? Start { get; set; }

        public string? End { get; set; }

        public CheckExtractSearchByDateRequest(string start, string end)
        {
            Id = Guid.NewGuid();
            Start = start;
            End = end;
        }
    }
}