namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao
{
    public class DownloadInutilizacao : Entity, IAggregateRoot
    {
        public DownloadInutilizacao(string chave, string tpAmb,
            string tpDown)
        {
            Chave = chave;
            TpAmb = tpAmb;
            TpDown = tpDown;

        }
        
        public string? Chave { get; private set; }
        
        public string? TpAmb { get; private set; }
        
        public string? TpDown { get; private set; }
        
    }
}