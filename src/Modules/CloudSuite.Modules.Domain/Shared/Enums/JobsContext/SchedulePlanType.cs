using CloudSuite.Modules.Domain.Models.JobsContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Shared.Enums.JobsContext
{
    [Serializable]
    public enum SchedulePlanType 
    {
        
        Interval = 1,
        Daily = 2,
        Weekly = 3,       
        Monthly = 4
    }
}
