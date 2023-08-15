using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao
{
    public class Download : Entity, IAggregateRoot
    {
        public Download(Guid id, string? chNFe, string? tpAmb, string? tpDown)
        {
            Id = id;
            ChNFe = chNFe;
            TpAmb = tpAmb;
            TpDown = tpDown;
        }

        public string? ChNFe { get; private set; }
        
        public string? TpAmb { get; private set; }
        
        public string? TpDown { get; private set; }
    }
}