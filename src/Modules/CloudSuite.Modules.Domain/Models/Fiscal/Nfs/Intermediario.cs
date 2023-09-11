using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.ValueObjects;
using CloudSuite.Modules.Common.Enums.NFs;
namespace CloudSuite.Modules.Domain.Models.Fiscal.Nfs
{
    public class Intermediario : Entity, IAggregateRoot
    {
        #region Events

        //public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Contructors

        public Intermediario()
        {
        }

        #endregion Contructors

        #region Propriedades

        public string? RazaoSocial { get; private set; }

        public Cnpj Cnpj { get; private set; }

        public string? InscricaoMunicipal { get; private set; }

        public string? CodigoMunicipio { get; private set; }

        public SituacaoTributaria SituacaoTributaria { get; set; }

        public Email Email { get; private set; }

        #endregion Propriedades
        
    }
}