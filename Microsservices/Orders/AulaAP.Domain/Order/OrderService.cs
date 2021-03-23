using AulaAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AulaAP.Domain.Services
{
    public class OrderService
    {
        private IOrderRepository repository;
        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Order>> GetAll() 
        {
            return await repository.GetAll();
        }
        public async Task Add(Order order)
        {
            if (!order.IsValid())
            {
                throw new Exception("O Pedido é inválido");
            }
            if (await repository.FindByOrderCode(order.OrderCode) != null) 
            {
                throw new Exception("O Pedido já existe no banco");
            }

            await repository.Add(order);

        }
    }
}
