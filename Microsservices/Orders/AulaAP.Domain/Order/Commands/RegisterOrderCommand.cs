using AulaAP.Domain.Entities;
using AulaAP.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Domain.Commands
{
    public class RegisterOrderCommand : Command, IRequest
    {
        public List<Product> Products { get; set; }
}
}
