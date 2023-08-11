using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class WidgetZone : Entity, IAggregateRoot
    {
        public WidgetZone(Guid id)
        {
            Id = id;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
