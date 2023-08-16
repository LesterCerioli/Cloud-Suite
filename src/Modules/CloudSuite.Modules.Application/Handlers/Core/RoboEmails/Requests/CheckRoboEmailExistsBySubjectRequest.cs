using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests
{
    public class CheckRoboEmailExistsBySubjectRequest : IRequest<CheckRoboEmailExistsBySubjectResponse>
    {
        public Guid Id { get; private set; }
        public string? Subject { get; private set; }
        public CheckRoboEmailExistsBySubjectRequest(string subject)
        {
            Id = Guid.NewGuid();
            Subject = subject;
        }
    }
}