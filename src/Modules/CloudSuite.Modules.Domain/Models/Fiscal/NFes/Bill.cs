using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes
{
    public class Bill : Entity, IAggregateRoot
    {
        public Bill(Guid id, string? number, decimal? originalValue, decimal? discountValue, decimal? netValue, bool? modified)
        {
            Id = id;
            Number = number;
            OriginalValue = originalValue;
            DiscountValue = discountValue;
            NetValue = netValue;
            Modified = modified;
        }

        public Bill() {}

        //Propriedades de Fatura
        public string? Number { get; private set; }

        public decimal? OriginalValue { get; private set; }

        public decimal? DiscountValue { get; private set; }

        //Valor Líquido
        public decimal? NetValue { get; private set; }

        public bool? Modified { get; private set; }
    }
}