using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Fiscal.Domain.Models.NotaFiscal
{
    public class FusoHorarioCalculator : Entity, IAggregateRoot
    {
        public FusoHorarioCalculator(bool horarioVerao, bool horarioNormal)
        {
            HorarioVerao = horarioVerao;
            HorarioNormal = horarioNormal;
        }

        public bool HorarioVerao { get; private set; }

        public bool HorarioNormal { get; private set; }
        
    }
}