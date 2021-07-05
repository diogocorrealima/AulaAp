using AulaAP.Application.ViewModels;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaAP.Tests.Mocks.Entities
{
    public static class ProductViewModelMock
    {

        public static List<ProductViewModel> GenerateProductsSuccess(int quantity)
        {

            var products = new Faker<ProductViewModel>("pt_BR")
                            .RuleFor(p => p.Id, f => f.Random.Guid().ToString())
                            .RuleFor(p => p.Name, f => f.Commerce.ProductMaterial())
                            .RuleFor(p => p.Quantity, f => f.Random.Int(1, 100))
                            .RuleFor(p => p.Value, f => Convert.ToDecimal(f.Commerce.Price(1,1000)))
                            .Generate(quantity)
                            .ToList();
            return products;

        }
    }
}
