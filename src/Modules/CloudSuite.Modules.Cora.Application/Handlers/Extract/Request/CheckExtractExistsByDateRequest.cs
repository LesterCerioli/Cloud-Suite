using CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses;
using MediatR;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extract.Request
{
    public class CheckExtractExistsByDateRequest : IRequest<CheckExtractExistsByDateResponse>
    {
        public Guid Id { get; private set; }

        public DateTimeOffset StartDate { get; private set; }

        public DateTimeOffset EndDate { get; private set; }

        public CheckExtractExistsByDateRequest(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            Id = Guid.NewGuid();
            StartDate = startDate;
            EndDate = endDate;
        }

        public CheckExtractExistsByDateRequest() {}
    }
}

