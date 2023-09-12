using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Fiscal.JobsContext
{
    public class JobContextModel : Entity, IAggregateRoot
    {
        [JsonProperty(PropertyName = "job_id")]
        public Guid JobId { get; private set; }

        [JsonProperty(PropertyName = "aborted")]
        public bool Aborted { get; private set; }

        [JsonProperty(PropertyName = "priority")]
        public JobPriority Priority { get; private set; }

        [JsonProperty(PropertyName = "attributes")]
        public dynamic Attributes { get; private set; }

        [JsonProperty(PropertyName = "result")]
        public dynamic Result { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public JobType Type { get; private set; }

        internal JobContext()
        {

        }
        
    }
}