using CloudSuite.Infrastructure.Data.Core.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Services.Core.API.Tests
{
    public class CloudSuiteCoreAPITest : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<CloudSuiteDbContext>));

                services.AddDbContext<CloudSuiteDbContext>(options =>
                    options.UseInMemoryDatabase("CloudSuiteDatabase", root));
            });

            return base.CreateHost(builder);
        }
    }
}
