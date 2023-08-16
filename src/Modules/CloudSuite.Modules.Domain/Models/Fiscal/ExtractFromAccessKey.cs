namespace CloudSuite.Modules.Domain.Models.Fiscal
{
    public class ExtractFromAccessKey
    {
        protected string AccessKey { get; set; }

        public ExtractFromAccessKey(string _accessKey)
        {
            AccessKey = _accessKey;
        }

        public string? UfCode { get { return AccessKey.Substring(0, 2); } }

        public int? Year { get { return Convert.ToInt32(AccessKey.Substring(2, 2)); } }

        public int? Month { get { return Convert.ToInt32(AccessKey.Substring(4, 2)); } }

        public string? CnpjCompany { get { return AccessKey.Substring(6, 14); } }

        /// <summary>
        /// More info : http://www.sefaz.go.gov.br/NETACCESS/AIDF_Eletronica/ModeloAidf/001frmListaDocumentosAIDF.asp
        /// </summary>
        public string DocModel { get { return AccessKey.Substring(20, 2); } }

        public string? DocSerie { get { return AccessKey.Substring(22, 3); } }

        public string? DocNumber { get { return AccessKey.Substring(25, 9); } }
    }
}