using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain
{
    public class Devops : Entity, IAggregateRoot
    {
        public Devops(string? name, string? age)
        {
            Name = name;
            Age = age;
        }


        public string? Name { get; private set; }

        public string? Age { get; private set; }
    }
}