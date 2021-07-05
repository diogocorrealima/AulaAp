using AulaAP.Application;
using AulaAP.Application.ViewModels;
using AulaAP.Domain.Entities;
using AulaAP.Domain.Interfaces;
using AulaAP.Services.Api.Controllers;
using AulaAP.Tests.Mocks.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AulaAP.Tests
{
    public class OrdersControllerTest
    {
        public OrdersController ordersController { get; set; }
        public Mock<ILogger<OrdersController>> mockLogger { get; set; }
        public Mock<IOrderApplication> mockOrderApplication { get; set; }
        public Mock<IOrderRepository> mockOrderRepository { get; set; }


        public OrdersControllerTest()
        {
            mockLogger = new Mock<ILogger<OrdersController>>();
            mockOrderApplication = new Mock<IOrderApplication>();
            mockOrderRepository = new Mock<IOrderRepository>();


            ordersController = new OrdersController(mockLogger.Object, mockOrderApplication.Object, mockOrderRepository.Object);
        }
        [Fact]
        public async Task OrdersController_CriarUmPedido_ComSucesso()
        {
            //Arrange(Organizar/Mockar)
            OrderCreateViewModel orderCreateViewModel = new OrderCreateViewModel()
            {
                Products = ProductViewModelMock.GenerateProductsSuccess(2)
            };

            //Act(Fazer/Executar)
            var result = (await ordersController.Post(orderCreateViewModel)) as ObjectResult;

            //Assert(Confirmar, Afirmar, Validar)
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 200);
        }
        [Fact]
        public async Task OrdersController_CriarUmPedido_ComErroDeViewModel()
        {
            //Arrange(Organizar/Mockar)
            OrderCreateViewModel orderCreateViewModel = new OrderCreateViewModel()
            {
                Products = new List<ProductViewModel>()
            };

            //Act(Fazer/Executar)
            var result = (await ordersController.Post(orderCreateViewModel)) as ObjectResult;

            //Assert(Confirmar, Afirmar, Validar)
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 400);
            Assert.Equal(result.Value.ToString(), "{ Erro = O Pedido está incorreto. }");
        }
        [Fact]
        public async Task OrdersController_ConsultarUmPedidoPeloNumero_ComSucesso()
        {
            //Arrange(Organizar/Mockar)
            string orderCode = Order.GenerateOrderCode();
            mockOrderRepository
                .Setup(or => or.FindByOrderCode(orderCode).Result)
                .Returns(new Order(orderCode, null));
            //Act(Fazer/Executar)
            var result = (await ordersController.Get(orderCode)) as ObjectResult;

            //Assert(Confirmar, Afirmar, Validar)
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 200);
            Assert.IsType(typeof(Order),result.Value);
            Assert.Equal(((Order)result.Value).OrderCode, orderCode);
        }
    }
}
