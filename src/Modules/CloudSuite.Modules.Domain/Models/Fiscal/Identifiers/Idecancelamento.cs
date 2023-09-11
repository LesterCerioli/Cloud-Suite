using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Fiscal.Identifiers
{
    public class Idecancelamento : Entity, IAggregateRoot
    {
        #endregion Constructors

        #region Propriedades

        
        public PedidoCancelamento Pedido { get; }

        public string MotivoCancelamento { get; set; }

        public DateTime DataHora { get; set; }

        public DFeSignature Signature { get; internal set; }

        #endregion Propriedades
        
    }
}