using CloudSuite.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class State : EntityBase
    {
        public State(long id)
        {
            Id = id;
        }
        
        public string? StateName { get; set; }

        [MaxLength(2)]
        public string? UF { get; set; }

        public Country Country { get; set; }


    }
}