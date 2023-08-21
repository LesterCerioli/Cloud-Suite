using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.JobsContext
{
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
    }
}
