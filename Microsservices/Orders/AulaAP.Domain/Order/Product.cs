using AulaAP.Domain.Shared;

namespace AulaAP.Domain.Entities
{
    public class Product : Entity<string>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}