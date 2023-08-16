using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao
{
    public class DownloadEvento : Entity, IAggregateRoot
    {
        public DownloadEvento(string? chNFe, string? tpAmb, string? tpDown, string? tpEvento, string? nSeqEvento)
        {
            ChNFe = chNFe;
            TpAmb = tpAmb;
            TpDown = tpDown;
            TpEvento = tpEvento;
            NSeqEvento = nSeqEvento;
        }

        public string? ChNFe { get; private set; }
        
        public string? TpAmb { get; private set; }
        
        public string? TpDown { get; private set; }
        
        public string? TpEvento { get; private set; }
        
        public string? NSeqEvento { get; private set; }
    }
}