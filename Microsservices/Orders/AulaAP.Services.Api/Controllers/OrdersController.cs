using AulaAP.Application;
using AulaAP.Application.ViewModels;
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
    public class OrdersController : ControllerBase
    {

        private readonly ILogger<OrdersController> logger;
        private readonly IOrderApplication orderApplication;

        public OrdersController(ILogger<OrdersController> logger, IOrderApplication orderApplication)
        {
            this.logger = logger;
            this.orderApplication = orderApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderCreateViewModel orderCreateViewModel)
        {
            try
            {
                logger.LogInformation("Iniciando criação do pedido: {0}", orderCreateViewModel);
                await orderApplication.CreateOrder(orderCreateViewModel);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
