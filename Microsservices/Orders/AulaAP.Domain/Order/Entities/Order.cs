using AulaAP.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaAP.Domain.Entities
{
    public class Order : Entity<string>
    {
        public Order(string orderCode, ICollection<Product> products)
        {
            OrderCode = orderCode;
            Products = products;
        }

        public string OrderCode { get; private set; }
        public ICollection<Product> Products { get; private set; }
        public decimal TotalValue() => Products.Any() ? Products.Sum(p => p.Value * p.Quantity) : 0;
        public static string GenerateOrderCode() => DateTime.Now.ToString("ddMMyyyyHHmmss") + new Random().Next(1, 99999);

        public override bool IsValid()
        {
            return true;
        }
    }
}
