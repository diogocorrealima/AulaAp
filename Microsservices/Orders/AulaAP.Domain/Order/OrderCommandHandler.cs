using AulaAP.Domain.Commands;
using AulaAP.Domain.Entities;
using AulaAP.Domain.Events;
using AulaAP.Domain.Interfaces;
using AulaAP.Domain.Shared;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AulaAP.Domain.Services
{
    public class OrderCommandHandler : IRequestHandler<RegisterOrderCommand>
    {
        private readonly IOrderRepository repository;
        private readonly IMediator mediator;
        public OrderCommandHandler(IOrderRepository repository, IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(RegisterOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(Order.GenerateOrderCode(), request.Products.ToList());

            if (!order.IsValid())
            {
                order.validationResult.Errors.ToList().ForEach(async error =>
                {
                    var notification = new DomainNotification(error.PropertyName, error.ErrorMessage);
                    await mediator.Publish(notification);
                });
                
                return Unit.Value;

            }
            if (await repository.FindByOrderCode(order.OrderCode) != null)
            {
                var notification = new DomainNotification("Pedido", "O Pedido já existe no banco");
                await mediator.Publish(notification);
                return Unit.Value;
            }

            await repository.Add(order);

            var successEvent = new RegisteredOrderEvent(order.OrderCode);
            await mediator.Publish(successEvent);
            return Unit.Value;
        }
    }
}
