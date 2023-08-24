using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao
{
    public class Inutilizacao : Entity, IAggregateRoot
    {
        public Inutilizacao(int? cUF, string tpAmb, string? ano, Cnpj cnpj, string? serie, string? nNFIni, string? nNFFin, string? xJust)
        {
            CUF = cUF;
            this.TpAmb = tpAmb;
            Ano = ano;
            Cnpj = cnpj;
            Serie = serie;
            NNFIni = nNFIni;
            NNFFin = nNFFin;
            XJust = xJust;
        }

        public int? CUF { get; private set; }
        
        public string TpAmb { get; set; }
        
        public string? Ano { get; private set; }
        
        public Cnpj Cnpj { get; private set; }
        
        public string? Serie { get; set; }
        
        public string? NNFIni { get; set; }
        
        public string? NNFFin { get; set; }
        
        public string? XJust { get; set; }
    }
}