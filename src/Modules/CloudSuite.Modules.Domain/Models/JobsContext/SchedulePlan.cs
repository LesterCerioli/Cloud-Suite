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
    public class SchedulePlan 
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public SchedulePlanType Type { get; set; }

        [JsonProperty(PropertyName = "start_date")]
        public DateTime? StartDate { get; set; }

        [JsonProperty(PropertyName = "end_date")]
        public DateTime? EndDate { get; set; } 

        [JsonProperty(PropertyName = "schedule_days")]
        public SchedulePlanDaysOfWeek ScheduledDays { get; set; }

        [JsonProperty(PropertyName = "interval_in_minutes")]
        public int? IntervalInMinutes { get; set; }

        [JsonProperty(PropertyName = "start_timespan")]
        public int? StartTimespan { get; set; }

        [JsonProperty(PropertyName = "end_timespan")]
        public int? EndTimespan { get; set; }

        [JsonProperty(PropertyName = "last_trigger_time")]
        public DateTime? LastTriggerTime { get; set; }

        [JsonProperty(PropertyName = "next_trigger_time")]
        public DateTime? NextTriggerTime { get; set; }

        [JsonProperty(PropertyName = "job_type_id")]
        public Guid JobTypeId { get; set; }

        [JsonProperty(PropertyName = "job_type")]
        public JobType JobType { get; set; }

        [JsonProperty(PropertyName = "job_attributes")]
        public dynamic JobAttributes { get; set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        [JsonProperty(PropertyName = "last_started_job_id")]
        public Guid? LastStartedJobId { get; set; }

        [JsonProperty(PropertyName = "created_on")]
        public DateTime CreatedOn { get; internal set; }

        [JsonProperty(PropertyName = "last_modified_by")]
        public Guid? LastModifiedBy { get; set; }

        [JsonProperty(PropertyName = "last_modified_on")]
        public DateTime LastModifiedOn { get; internal set; }
    }
}
