

using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface IEmailRepository
    {
        Task<RoboEmail> GetBySubject(string subject);

        Task<RoboEmail> GetByReceivedTime(DateTimeOffset receivedTime);

        Task<RoboEmail> GetByMessageRecipient(string messageRecipient);

        Task<IEnumerable<RoboEmail>> GetList();

        Task Add(RoboEmail roboEmail);

        void Update(RoboEmail roboEmail);

        void Remove(RoboEmail roboEmail);
         
    }
}