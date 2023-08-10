using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Events.Core
{
    public class UserSignedIn : INotification
    {
        public long UserId { get; set; }
    }
}
