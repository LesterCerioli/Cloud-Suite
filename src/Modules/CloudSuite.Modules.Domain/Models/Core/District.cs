using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class District : Entity, IAggregateRoot
    {
        private readonly List<State> _states;

        public District(Guid id, string name, string type, string location)
        {
            Id = id;
            _states = new List<State>();
            Name = name;
            Type = type;
            Location = location;
        }

        public District() { }

        public IReadOnlyCollection<State> States => _states.AsReadOnly();

        public State State { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; private set; }

        [StringLength(450)]
        public string? Type { get; private set; }

        public string? Location { get; private set; }

    }
}