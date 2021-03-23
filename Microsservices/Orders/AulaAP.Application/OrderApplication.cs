using AulaAP.Application.ViewModels;
using AulaAP.Domain.Commands;
using AulaAP.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Threading.Tasks;

namespace AulaAP.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public OrderApplication(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;

        }
        public async Task CreateOrder(OrderCreateViewModel orderCreateViewModel)
        {
            RegisterOrderCommand command = mapper.Map<OrderCreateViewModel, RegisterOrderCommand>(orderCreateViewModel);
            await mediator.Send(command);

        }
    }
}
