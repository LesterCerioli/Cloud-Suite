using CloudSuite.Infrastructure.Data.Core.Context;
using Microsoft.Extensions.DependencyInjection;

namespace CloudSuite.Infrastructure.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterService(IServiceCollection service)
        {
            service.AddScoped<CloudSuiteDbContext>();

            // Application
            

        }
    }
}