using AulaAP.Application;
using AulaAP.Application.ViewModels;
using AulaAP.Domain.Interfaces;
using AulaAP.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaAP.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : MainController
    {

        private readonly ILogger<OrdersController> logger;
        private readonly IOrderApplication orderApplication;
        private readonly IOrderRepository orderRepository;

        public OrdersController(ILogger<OrdersController> logger, IOrderApplication orderApplication, IOrderRepository orderRepository, INotificationHandler<DomainNotification> notificationHandler, IMediator mediator)
            : base(notificationHandler, mediator)
        {
            this.logger = logger;
            this.orderApplication = orderApplication;
            this.orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderCreateViewModel orderCreateViewModel)
        {
            try
            {
                if (!ValidOperation())
                {
                    return Response();
                }
                logger.LogInformation("Iniciando criação do pedido: {0}", orderCreateViewModel);
                await orderApplication.CreateOrder(orderCreateViewModel);
                return Response(orderCreateViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{orderCode}")]
        public async Task<IActionResult> Get(string orderCode)
        {
            try
            {
                if (string.IsNullOrEmpty(orderCode))
                {
                    return BadRequest(new { Erro = "O productCode deve ser preenchido" });
                }

                var result = await orderRepository.FindByOrderCode(orderCode);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
