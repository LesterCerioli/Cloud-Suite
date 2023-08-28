using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Entidade : Entity, IAggregateRoot
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Slug { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; set; }

        public Guid EntidadeTipoId { get; private set; }

        public EntidadeTipo EntidadeTipo { get; private set; }
    }
}
