using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Application.IoC
{
    public static class ApplicationDependencies
    {
        public static void RegisterApplicationDependencies(this IServiceCollection service) =>
            service.AddScoped<IOrderApplication, OrderApplication>();

    }
}
