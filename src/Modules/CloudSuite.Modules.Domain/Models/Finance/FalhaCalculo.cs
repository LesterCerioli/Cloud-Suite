using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Finance
{
    public class FalhaCalculo : Entity, IAggregateRoot
    {
        public FalhaCalculo(Guid id, bool? erro, string? mensagem)
        {
            Id = id;
            Erro = erro;
            Mensagem = mensagem;
        }

        public bool? Erro {get; private set;}
        
        public string? Mensagem { get; private set; }
        
    }
}