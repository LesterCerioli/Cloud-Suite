using CloudSuite.Modules.Domain.Shared.Enums.JobsContext;
using NetDevPack.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.JobsContext
{

    [Serializable]
    internal class JobResultWrapper 
    {
        [JsonProperty(PropertyName = "Result")]
        public dynamic Result { get; set; } = null;
    }

    [Serializable]
    public class Job 
    {
        [JsonProperty(PropertyName = "type_id")]
        public Guid TypeId { get; set; }

        [JsonProperty(PropertyName = "type")]
        public JobType Type { get; set; }

        [JsonProperty(PropertyName ="type_name")]
        public string TypeName { get; set; }

        [JsonProperty(PropertyName = "complete_class_name")]
        public string CompleteClassName { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public dynamic Attributes { get; set; }

        [JsonProperty(PropertyName = "result")]
        public dynamic Result { get; set; }

        [JsonProperty(PropertyName = "status")]

        public JobStatus Status { get; set; }

        [JsonProperty(PropertyName = "priority")]
        public JobPriority Priority { get; set; }

        [JsonProperty(PropertyName = "started_on")]
        public DateTime? StartOn { get; set; }

        [JsonProperty(PropertyName = "finished_on")]
        public DateTime? FinishedOn { get; set; }

        [JsonProperty(PropertyName = "aborted_by")]
        public Guid? AbortedBy { get; set; }

        [JsonProperty(PropertyName = "canceled_by")]
        public Guid? CanceledBy { get; set; }

        [JsonProperty(PropertyName = "error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "schedule_plan_id")]
        public Guid? SchedulePlanId { get; set; }

        [JsonProperty(PropertyName = "created_on")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public Guid? CreatedBy { get; set; }

        [JsonProperty(PropertyName = "last_modified_on")]
        public DateTime LastModifiedOn { get; set; }

        [JsonProperty(PropertyName = "last_modified_by")]
        public Guid? LastModifiedBy { get; set; }
    }
}
