using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Finance
{
    public class Emprestimo : Entity, IAggregateRoot
    {
        public Emprestimo(Guid id, double valorEmprestimo, int? numMeses, double taxaPercentual, double valorFinalComJuros)
        {
            Id = id;
            ValorEmprestimo = valorEmprestimo;
            NumMeses = numMeses;
            TaxaPercentual = taxaPercentual;
            ValorFinalComJuros = valorFinalComJuros;
        }

        public double ValorEmprestimo { get; private set; }
        
        public int? NumMeses { get; private set; }
        
        public double TaxaPercentual { get; private set; }
        
        public double ValorFinalComJuros { get; private set; }
    }
}