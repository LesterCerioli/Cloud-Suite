using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Shared.Enums.JobsContext
{
    [Serializable]
    public enum JobStatus
    {
        Pending = 1,
        Running = 2,
        Canceled = 3,
        Failed = 4,
        Finished = 5,
        Aborted = 6
    }
}
