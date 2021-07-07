
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AulaAP.Domain.Shared
{
    public static class DomainSharedDependencies
    {
        public static void RegisterDomainSharedDependencies(this IServiceCollection service) =>
            service
            .AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        
    }
}
