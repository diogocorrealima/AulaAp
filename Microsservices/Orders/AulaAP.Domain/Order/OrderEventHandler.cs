using AulaAP.Domain.Commands;
using AulaAP.Domain.Entities;
using AulaAP.Domain.Events;
using AulaAP.Domain.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AulaAP.Domain.Services
{
    public class OrderEventHandler : INotificationHandler<RegisteredOrderEvent>
    {
        public OrderEventHandler()
        {
        }

        public async Task Handle(RegisteredOrderEvent notification, CancellationToken cancellationToken)
        {

            //Enviar e-mail
        }
    }
}
