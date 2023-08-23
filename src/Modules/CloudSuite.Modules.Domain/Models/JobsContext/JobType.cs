using CloudSuite.Modules.Domain.Shared.Enums.JobsContext;
using NetDevPack.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.JobsContext
{
    [Serializable]
    public class JobType 
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "default_job_priority_id")]
        public JobPriority DefaultPriority { get; set; }

        [JsonProperty(PropertyName = "assembly")]
        public string Assembly { get; set; }

        [JsonProperty(PropertyName = "complete_class_name")]
        public string CompleteClassName { get; set; }

        [JsonProperty(PropertyName = "allow_single_instance")]
        public bool AllowSingleInstance { get; set; }

        [JsonIgnore] 
        public Type ErpJobType { get; set; }

    }
}
