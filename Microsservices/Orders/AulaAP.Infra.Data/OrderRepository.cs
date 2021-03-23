using AulaAP.Domain.Entities;
using AulaAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AulaAP.Infra.Data
{
    public class OrderRepository : IOrderRepository
    {
        public async Task Add(Order order)
        {
            await Task.FromResult(order);
        }

        public async Task<Order> FindByOrderCode(string orderCode)
        {
            var products = new List<Product>();
            products.Add(new Product(Guid.NewGuid().ToString(),"Dipirona", 10, 2));
            return await Task.FromResult(new Order(Order.GenerateOrderCode(), products));
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = new List<Order>();
            var products = new List<Product>();
            products.Add(new Product(Guid.NewGuid().ToString(), "Dipirona", 10, 2));
            products.Add(new Product(Guid.NewGuid().ToString(), "Atadura", 3, 10));

            orders.Add(new Order(Order.GenerateOrderCode(), products));
            orders.Add(new Order(Order.GenerateOrderCode(), products));

            return await Task.FromResult(orders);
        }
    }
}
