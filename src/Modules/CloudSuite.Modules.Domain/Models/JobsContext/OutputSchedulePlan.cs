using CloudSuite.Modules.Domain.Shared.Enums.JobsContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.JobsContext
{
    public class OutputSchedulePlan
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; private set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public SchedulePlanType Type { get; private set; }

        [JsonProperty(PropertyName = "start_date")]
        public DateTime? StartDate { get; private set; }

        [JsonProperty(PropertyName = "end_date")]
        public DateTime? EndDate { get; private set; } 

        [JsonProperty(PropertyName = "schedule_days")]
        public SchedulePlanDaysOfWeek ScheduledDays { get; private set; }

        [JsonProperty(PropertyName = "interval_in_minutes")]
        public int? IntervalInMinutes { get; private set; }

        [JsonProperty(PropertyName = "start_timespan")]
        public DateTime? StartTimespan { get; private set; }

        [JsonProperty(PropertyName = "end_timespan")]
        public DateTime? EndTimespan { get; private set; }

        [JsonProperty(PropertyName = "last_trigger_time")]
        public DateTime? LastTriggerTime { get; private set; }

        [JsonProperty(PropertyName = "next_trigger_time")]
        public DateTime? NextTriggerTime { get; private set; }

        [JsonProperty(PropertyName = "job_type_id")]
        public Guid JobTypeId { get; private set; }

        [JsonProperty(PropertyName = "job_type")]
        public JobType JobType { get; private set; }

        [JsonProperty(PropertyName = "job_attributes")]
        public dynamic JobAttributes { get; private set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; private set; }

        [JsonProperty(PropertyName = "last_started_job_id")]
        public Guid? LastStartedJobId { get; private set; }

        [JsonProperty(PropertyName = "created_on")]
        public DateTime CreatedOn { get; internal set; }

        [JsonProperty(PropertyName = "last_modified_by")]
        public Guid? LastModifiedBy { get; private set; }

        [JsonProperty(PropertyName = "last_modified_on")]
        public DateTime LastModifiedOn { get; internal set; }
    }
}
