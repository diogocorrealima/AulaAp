using AulaAP.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Infra.Data.IoC
{
    public static class DataDependencies
    {
        public static void RegisterDataDependencies(this IServiceCollection service) =>
            service.AddScoped<IOrderRepository, OrderRepository>();
    }
}
