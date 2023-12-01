using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extract.Request
{
    public class CheckExtractExistByCostumerRequest : IRequest<CheckExtractExistByCostumerResponse>
    {
        public Guid Id { get; private set; }

        public Customer Customer { get; private set; }

        public CheckExtractExistByCostumerRequest(Customer customer)
        {
            Id = Guid.NewGuid();
            Customer = customer;
        }

        public CheckExtractExistByCostumerRequest() {}
    }
}

