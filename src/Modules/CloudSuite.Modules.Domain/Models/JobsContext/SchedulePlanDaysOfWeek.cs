using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.JobsContext
{
    public class SchedulePlanDaysOfWeek
    {
        [JsonProperty(PropertyName = "scheduled_on_sunday")]
        public bool ScheduledOnSunday { get; set; }

        [JsonProperty(PropertyName = "scheduled_on_monday")]
        public bool ScheduledOnMonday { get; set; }

        [JsonProperty(PropertyName = "scheduled_on_tuesday")]
        public bool ScheduledOnTuesday { get; set; }

        [JsonProperty(PropertyName = "scheduled_on_wednesday")]
        public bool ScheduledOnWednesday { get; set; }

        [JsonProperty(PropertyName = "scheduled_on_thursday")]
        public bool ScheduledOnThursday { get; set; }

        [JsonProperty(PropertyName = "scheduled_on_friday")]
        public bool ScheduledOnFriday { get; set; }

        [JsonProperty(PropertyName = "scheduled_on_saturday")] 
        public bool ScheduledOnSaturday { get; set; }

        public bool HasOneSelectedDay()
        {
            return ScheduledOnSunday || ScheduledOnMonday || ScheduledOnTuesday || ScheduledOnWednesday ||
                ScheduledOnThursday || ScheduledOnFriday || ScheduledOnSaturday;
        }
    }
}
