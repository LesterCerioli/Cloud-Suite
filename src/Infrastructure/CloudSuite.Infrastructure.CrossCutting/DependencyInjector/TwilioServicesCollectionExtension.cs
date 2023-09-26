using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.Services.Implementations.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.CrossCutting.DependencyInjector
{
    public static class TwilioServsicesCollectionExtension
    {
        public static IServiceCollection AddTwilioServices(this IServiceCollection services) 
        {
            services.AddScoped<ITwilioSmsServices, TwilioSmsServices>();

            return services;
        }
    }
}
