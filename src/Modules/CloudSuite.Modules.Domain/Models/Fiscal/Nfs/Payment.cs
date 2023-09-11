using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Common.Enums.NFs;
namespace CloudSuite.Modules.Domain.Models.Fiscal.Nfs
{
    public class Payment : Entity, IAggregateRoot
    {
         #region Events

        //public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Contructors

        public Payment()
        {
            Parcelas = new ParcelasCollection();
        }

        #endregion Contructors

        #region Propriedades

        public PaymentMethod PaymentMethod { get; private set; }

        public int? QtdParcela { get; private set; }

        public ParcelasCollection Parcelas { get; }

        #endregion Propriedades
        
    }
}