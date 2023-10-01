using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Modules.Domain.Models.Fiscal.NotaFiscal
{
    public class FusoHorarioCalculator : Entity, IAggregateRoot
    {
        private readonly TimeZoneInfo _fusoHorario;
        private readonly TimeSpan _fusoHorarioOffset;

        public FusoHorarioCalculator(TimeZoneInfo fusoHorario)
        {
            _fusoHorario = fusoHorario;
            _fusoHorarioOffset = ObtemOffsetFusoHorario(_fusoHorario);
        }

        private bool? EstaEmPeriodoHorarioVerao(DateTime data)
        {
            return _fusoHorario.IsDaylightSavingTime(data);
        }

        public TimeSpan ObtemFusoHorarioOffset(DateTime data)
        {
            var offset = _fusoHorarioOffset;
            if (EstaEmPeriodoHorarioVerao(data))
            {
                offset = offset.Add(TimeSpan.FromHours(-1));
            }
            return offset;
        }

        private static TimeSpan ObtemOffsetFusoHorario(TimeZoneInfo fusoHorario)
        {
            return fusoHorario.BaseUtcOffset;
        }
        
    }
}