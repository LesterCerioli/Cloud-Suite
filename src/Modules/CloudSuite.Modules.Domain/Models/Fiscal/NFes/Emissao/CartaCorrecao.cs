namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao
{
    public class CartaCorrecao : Entity, IAggregateRoot
    {
        public string? ChNFe { get; private set; }
        
        public string? TpAmb { get; private set; }
        
        public string? DhEvento { get; private set; }
        
        public string? NSeqEvento { get; private set; }
        
        public string? XCorrecao { get; private set; }
        
    }
}