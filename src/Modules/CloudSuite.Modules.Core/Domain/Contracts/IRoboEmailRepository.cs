using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Core.Domain.Models;

namespace CloudSuite.Modules.Core.Domain.Contracts
{
    public interface IRoboEmailRepository
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