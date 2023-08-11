using CloudSuite.Infrastructure.Models;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes
{
    public class AccessKeyNFe : EntityBase
    {
        public Cnpj Cnpj { get; set; }

        public string? CompanyName { get; set; }

        public string? FantasyCompany { get; set; }

        public Address Address { get; set; }

        
        //Inscricao Estadual
        public string? StateSubscription { get; set; }

        public string? InscricaoEstadualSubstitutoTributario { get; set; }

        public string? InscricaoMunicipal { get; set; }

        public string? CNAEFiscal { get; set; }
    }
}
