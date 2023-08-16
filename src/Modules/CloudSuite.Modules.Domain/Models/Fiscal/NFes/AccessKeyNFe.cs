using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes
{
    public class AccessKeyNFe : Entity, IAggregateRoot
    {
        public AccessKeyNFe(Guid id, Cnpj cnpj, string? companyName, string? fantasyCompany, Address address, string? stateSubscription, string? inscricaoEstadualSubstitutoTributario, string? inscricaoMunicipal, string? cNAEFiscal)
        {
            Id = id;
            Cnpj = cnpj;
            CompanyName = companyName;
            FantasyCompany = fantasyCompany;
            Address = address;
            StateSubscription = stateSubscription;
            InscricaoEstadualSubstitutoTributario = inscricaoEstadualSubstitutoTributario;
            InscricaoMunicipal = inscricaoMunicipal;
            CNAEFiscal = cNAEFiscal;
        }

        public AccessKeyNFe() {}

        public Cnpj Cnpj { get; private set; }

        public string? CompanyName { get; private set; }

        public string? FantasyCompany { get; private set; }

        public Address Address { get; private set; }

        
        //Inscricao Estadual
        public string? StateSubscription { get; private set; }

        public string? InscricaoEstadualSubstitutoTributario { get; private set; }

        public string? InscricaoMunicipal { get; private set; }

        public string? CNAEFiscal { get; private set; }
    }
}
