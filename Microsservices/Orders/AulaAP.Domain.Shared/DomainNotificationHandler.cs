using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AulaAP.Domain.Shared
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> domainNotifications;
        public DomainNotificationHandler()
        {
            domainNotifications = new List<DomainNotification>();
        }
        public async Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            domainNotifications.Add(notification);
        }
        public List<DomainNotification> GetNotifications()
        {
            return domainNotifications;
        }
        public bool HasNotifications()
        {
            return domainNotifications.Any();
        }
        public void Dispose() 
        {
            domainNotifications = new List<DomainNotification>();
        }
    }
}
