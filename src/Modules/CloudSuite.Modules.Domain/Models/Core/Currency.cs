using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Currency : Entity, IAggregateRoot
    {
        
        public Currency()
        {
            FormatCurrency = formatCurrency;
            CultureInfo = cultureInfo

        }
        
        public string? FormatCurrency { get; private set; }

        public string? CultureInfo { get; private set; }
    }
}