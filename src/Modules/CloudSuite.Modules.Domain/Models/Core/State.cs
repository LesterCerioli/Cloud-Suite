using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class State : Entity, IAggregateRoot
    {
        private readonly List<Country> _countries;

        public State(Guid id)
        {
            Id = id;
            _countries = new List<Country>();
        }
        
        public string? StateName { get; private set; }

        [MaxLength(2)]
        public string? UF { get; private set; }

        public Country Country { get; set; }

        public IReadOnlyCollection<Country> Countries => _countries.AsReadOnly();


    }
}