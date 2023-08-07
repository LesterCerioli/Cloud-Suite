﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Modules
{
    public interface IModuleInitializer
    {
        void ConfigureServices(IServiceCollection serviceCollection);

        //void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
