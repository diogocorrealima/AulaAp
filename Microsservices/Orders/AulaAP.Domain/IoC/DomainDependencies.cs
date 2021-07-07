using AulaAP.Domain.Commands;
using AulaAP.Domain.Events;
using AulaAP.Domain.Interfaces;
using AulaAP.Domain.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AulaAP.Domain.IoC
{
    public static class DomainDependencies
    {
        public static void RegisterDomainDependencies(this IServiceCollection service) =>
            service
            .AddMediatR(typeof(RegisterOrderCommand).GetTypeInfo().Assembly)
            .AddScoped<IRequestHandler<RegisterOrderCommand>, OrderCommandHandler>()
            .AddScoped<INotificationHandler<RegisteredOrderEvent>, OrderEventHandler>();
        
    }
}
