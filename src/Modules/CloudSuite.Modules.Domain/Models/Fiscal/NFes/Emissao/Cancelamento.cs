using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao
{
    public class Cancelamento : Entity, IAggregateRoot
    {
        public Cancelamento(Guid id, string? chNFe, string? tpAmb, string? dhEvento, string? nProt, string? xJust)
        {
            Id = id;
            ChNFe = chNFe;
            TpAmb = tpAmb;
            DhEvento = dhEvento;
            NProt = nProt;
            XJust = xJust;
        }

        public string? ChNFe { get; private set; }
        
        public string? TpAmb { get; private set; }
        
        public string? DhEvento { get; private set; }
        
        public string? NProt { get; private set; }
        
        public string? XJust { get; private set; }
    }
}