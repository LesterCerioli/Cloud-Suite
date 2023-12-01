using CloudSuite.Infrastructure.Data.Cora.Context;
using Microsoft.Extensions.DependencyInjection;

namespace CloudSuite.Infrastructure.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterService(IServiceCollection service)
        {
            service.AddScoped<CoraDbContext>();

            // Application
            

        }
    }
}