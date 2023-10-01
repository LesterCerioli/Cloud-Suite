namespace CloudSuite.Modules.Domain.Contracts.Fiscal
{
    public interface IPossuiDocumentoIdentificador
    {
        string CNPJ { get; set; }
        string CPF { get; set; }
    }
}