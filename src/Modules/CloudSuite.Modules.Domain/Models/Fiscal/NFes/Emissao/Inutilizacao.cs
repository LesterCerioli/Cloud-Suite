namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao
{
    public class Inutilizacao : Entity, IAggregateRoot
    {
        public int? CUF { get; private set; }
        
        public string tpAmb { get; set; }
        
        public string? Ano { get; private set; }
        
        public Cnpj Cnpj { get; private set; }
        
        public string? Serie { get; set; }
        
        public string? NNFIni { get; set; }
        
        public string? NNFFin { get; set; }
        
        public string? XJust { get; set; }
    }
}