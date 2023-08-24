using CloudSuite.Modules.Domain.Shared.Enums.JobsContext;
using NetDevPack.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.JobsContext
{
<<<<<<< HEAD
    [Serializable]
    public class JobType 
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "default_job_priority_id")]
        public JobPriority DefaultPriority { get; private set; }

        [JsonProperty(PropertyName = "assembly")]
        public string Assembly { get; private set; }

        [JsonProperty(PropertyName = "complete_class_name")]
        public string CompleteClassName { get; private set; }

        [JsonProperty(PropertyName = "allow_single_instance")]
        public bool AllowSingleInstance { get; private set; }

        [JsonIgnore] 
        public Type ErpJobType { get; private set; }

=======
<<<<<<< HEAD:src/Modules/CloudSuite.Modules.Domain/Models/JobsContext/JobType.cs
    public class JobType
=======
    public class StateViewModel
>>>>>>> b4b71ac91554233119de5d6dbb767686a42a3641:src/Modules/CloudSuite.Modules.Application/ViewModels/Core/StateViewModel.cs
    {
        public string? Code { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; set; }
>>>>>>> c21005c5fb1fb2c6728965dc0ce26fc938c49834
    }
}
