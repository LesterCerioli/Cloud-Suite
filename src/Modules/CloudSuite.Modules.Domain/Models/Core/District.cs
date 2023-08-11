using CloudSuite.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class District : EntityBase
    {
        public District(long id)
        {
            Id = id;
        }

        public District() { }

        public long StateId { get; set; }

        public State State { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; set; }

        [StringLength(450)]
        public string? Type { get; set; }

        public string? Location { get; set; }

    }
}