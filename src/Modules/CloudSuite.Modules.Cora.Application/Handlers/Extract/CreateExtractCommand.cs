using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato.Responses;
using CloudSuite.Modules.Cora.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using ExtractEntity = CloudSuite.Modules.Cora.Domain.Models.Extract;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extrato
{
    public class CreateExtractCommand : IRequest<CreateExtractResponse>
    {

        public Guid Id { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTimeOffset StartDate { get; set; }

        public decimal StartBalance { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTimeOffset EndDate { get; set; }

        public decimal EndBalance { get; set; }

        public Customer? Customer { get; set; }

        public Transaction? Transaction { get; set; }

        public decimal? AggregationsCreditTotal { get; private set; }

        public decimal? AggregationsDebitTotal { get; private set; }

        public string? HeaderBusinessName { get; private set; }

        public string? HeaderBusinessDocument { get; private set; }

        
        public ExtractEntity GetEntity()
        {
            return new ExtractEntity(
                this.StartDate,
                this.StartBalance,
                this.EndDate,
                this.EndBalance,
                this.Customer,
                this.Transaction,
                this.AggregationsCreditTotal,
                this.AggregationsDebitTotal,
                this.HeaderBusinessName,
                this.HeaderBusinessDocument);
        }

    }
}


