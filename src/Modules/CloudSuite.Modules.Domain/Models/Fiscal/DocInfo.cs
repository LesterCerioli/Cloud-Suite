using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Fiscal
{
    public class DocInfo : Entity, IAggregateRoot
    {
        
        public DocInfo(Guid id, string companyName, string accessKey,
             string total)
        {
            Id = id;
            CompanyName = companyName;
            AccessKey = accessKey;
            Total = total;

        }
        
        public string? CompanyName { get; set; }
        
        public string? AccessKey { get; set; }

        public string? Total { get; set; }

        public string? Html { get; set; }

        public decimal? TotalDecimal { get { return Convert.ToDecimal(Total); } }

        public string? TotalPresentation {get; private set;}

        public ExtractFromAccessKey InfoFromAccessKey { get { return new ExtractFromAccessKey(this.AccessKey); } }
    }
}