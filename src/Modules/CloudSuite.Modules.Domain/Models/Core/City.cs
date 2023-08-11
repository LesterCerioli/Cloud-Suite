using NetDevPack.Domain;
using System;
using System.Collections.Generic;
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
        
        public string? CityName { get; set; }

        public IReadOnlyCollection<State> States => _states.AsReadOnly();

        public State State { get; set; }
    }
}
