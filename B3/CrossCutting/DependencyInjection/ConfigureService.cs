﻿using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IInvestimentService, CdbService>();
        }
    }
}
