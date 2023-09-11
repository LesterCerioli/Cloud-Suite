using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Modules.Domain.Models.Fiscal.Nfs
{
    public class TomadorServico : Entity, IAggregateRoot
    {
        public Cnpj Cnpj { get; private set; }

        public string? InscricaoMunicipal { get; private set; }

        public string InscricaoEstadual { get; private set; }

        public string? DocTomadorEstrangeiro { get; private set; }

        public string? RazaoSocial { get; private set; }

        public string? NomeFantasia { get; private set; }

        public Address Address { get; private set;}

        
        public Contact Contact { get; private set; }

        public int Tipo { get; set; } //Utilize a classe TipoTomador
    }
}