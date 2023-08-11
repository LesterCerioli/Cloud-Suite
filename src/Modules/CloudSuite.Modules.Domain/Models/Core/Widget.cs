using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Widget : Entity, IAggregateRoot
    {
        protected Widget() { } // Private constructor required by EF Core

        public Widget(Guid id)
        {
            Id = id;
            CreatedOn = DateTimeOffset.Now;
        }

        public string? Code => Id.ToString();

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; set; }

        [StringLength(450)]
        public string? ViewComponentName { get; set; }

        [StringLength(450)]
        public string? CreateUrl { get; set; }

        [StringLength(450)]
        public string? EditUrl { get; set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public bool? IsPublished { get; set; }
    }
}
