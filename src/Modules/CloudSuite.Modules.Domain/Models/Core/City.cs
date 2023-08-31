using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class City : Entity, IAggregateRoot
    {
        private readonly List<State> _states;

        public City(Guid id)
        {
            Id = id;
            _states = new List<State>();
        }
        
        public City() { }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [MaxLength(100)]
        public string? CityName { get; private set; }

        public IReadOnlyCollection<State> States => _states.AsReadOnly();

        public State State { get; private set; }

        public Guid StateId { get; private set; }
    }
}
