using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Shared.Enums.JobsContext
{
    [Serializable]
    public enum JobPriority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Higher = 4,
        Higest = 5
    }
}
