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
        public WidgetZone(Guid id, string? name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Description { get; set; }
    }
}
