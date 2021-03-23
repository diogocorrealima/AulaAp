using AulaAP.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Domain.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.OrderCode).NotEmpty().WithMessage("O Código do Pedido é obrigatório");
            RuleFor(o => o.TotalValue()).GreaterThan(0).WithMessage("O Valor Total deve ser maior que 0");
            RuleFor(o => o.Products.Count).GreaterThan(0).WithMessage("O pedido precisa ter pelo menos 1 produto.");
        }
    }
}
