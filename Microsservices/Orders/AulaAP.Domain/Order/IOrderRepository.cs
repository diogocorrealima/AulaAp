using AulaAP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AulaAP.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> FindByOrderCode(string orderCode);
        Task Add(Order order);
    }
}