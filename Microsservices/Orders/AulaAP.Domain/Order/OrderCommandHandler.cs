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
    public class OrderCommandHandler : IRequestHandler<RegisterOrderCommand>
    {
        private IOrderRepository repository;
        public OrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RegisterOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(Order.GenerateOrderCode(), request.Products.ToList());

            if (!order.IsValid())
            {
                throw new Exception("O Pedido é inválido");
            }
            if (await repository.FindByOrderCode(order.OrderCode) != null)
            {
                throw new Exception("O Pedido já existe no banco");
            }

            await repository.Add(order);

            var result = new RegisteredOrderSuccessEvent(order.OrderCode);
            return Unit.Value;
        }
    }
}
