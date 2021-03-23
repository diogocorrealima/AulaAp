using AulaAP.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("O Nome do Produto é obrigatório");
            RuleFor(o => o.Value).GreaterThan(0).WithMessage("O Valor deve ser maior que 0");
            RuleFor(o => o.Quantity).GreaterThan(0).WithMessage("A Quantidade deve ser maior que 0");
        }
    }
}
