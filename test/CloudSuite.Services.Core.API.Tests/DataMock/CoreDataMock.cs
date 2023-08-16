using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Services.Core.API.Tests.DataMock
{
    public class CoreDataMock
    {
        public static async Task CreateContactName(CloudSuiteCoreAPITest cloudSuiteCoreAPITest)
        {
            using (var scope = ApplicationException.Services.CreateScope())
            {
                await cloudSuiteDbContext.Database.EnsureCreatedAsync();
            }
        }
    }
}
