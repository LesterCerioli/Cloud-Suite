using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services.Company
{
    public class CompanyServiceFakeTests
    {
        private readonly Mock<ICompanyRepository> _companyRepository;

        public CompanyServiceFakeTests()
        {
            _companyRepository = new Mock<ICompanyRepository>();
        }
    }
}
