using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class State : Entity, IAggregateRoot
    {
        public State(Guid id)
        {
            Id = id;
        }
        
        public string? StateName { get; set; }

        [MaxLength(2)]
        public string? UF { get; set; }

        public Country Country { get; set; }


    }
}