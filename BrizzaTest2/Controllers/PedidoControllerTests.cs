using Microsoft.VisualStudio.TestTools.UnitTesting;
using Britzza___v6.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Britzza___v6.Repository;
using Britzza___v6.Interfaces;
using Britzza___v6.Models;
using Moq;

namespace Britzza___v6.Controllers.Tests
{
    [TestClass()]
    public class PedidoControllerTests
    {
        private readonly PedidoRepository _pedidoRepository;
        private readonly string connectionString = "mongodb+srv://vandi123:vandiBritzza@cluster0.mjg9q9v.mongodb.net/";
        private readonly string databaseName = "britzza";

        public PedidoControllerTests()
        {
            _pedidoRepository = new PedidoRepository(connectionString, databaseName);
        }

        [TestMethod()]
        public void BuscaTodosPedidosTest()
        {
            //Arrange
            var controller = new PedidoController(_pedidoRepository);

            //Act
            var result = controller.BuscaTodosPedidos();
            //Assert 
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void BuscaPedidoPorDocumentoTest()
        {
            //Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var controller = new PedidoController(_pedidoRepository);
            string doc = "12345678910";
            ResultPedidoModel cl = new ResultPedidoModel() { BuscaDocumento = doc };
            //Act
            var result = controller.BuscaPedidoPorDocumento(cl);

            //Assert 
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CriaPedidoTest_Falha()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var controller = new PedidoController(pedidoRepositoryMock.Object);
            var model = new PedidoModel
            {
                Numero_Cliente = "1030757",
                Sabor_Pizza = "Calabresa",
                Tamanho_Pizza = "G",
                Status = "Criado",
                Quantidade_Pizza = 2,
                Bebida = "Coca-Cola",
                Quantidade_Bebida = 1,
                Forma_Pagamento = "Dinheiro",
                Enabled = true,
            };

            pedidoRepositoryMock.Setup(u => u.CriaPedido(It.IsAny<PedidoModel>())); // Configuração do Mock

            // Act
            var result = controller.CriaPedido(model) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod()]
        public void AlteraPedidoTest()
        {
            //Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var controller = new PedidoController(pedidoRepositoryMock.Object);
            var model = new PedidoModel
            {
                Numero_Cliente = "1030757",
                Sabor_Pizza = "Calabresa",
                Tamanho_Pizza = "G",
                Status = "Criado",
                Quantidade_Pizza = 2,
                Bebida = "Coca-Cola",
                Quantidade_Bebida = 1,
                Forma_Pagamento = "Dinheiro",
                Enabled = true,
            };

           pedidoRepositoryMock.Setup(u => u.AlteraPedido(It.IsAny<PedidoModel>())); // Configuração do Mock
            // Act
            var result = controller.AlteraPedido(model) as RedirectToActionResult;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void DeletaPedidoTest()
        {

            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var controller = new PedidoController(_pedidoRepository);
            string doc = "12345678910";

            PedidoModel cl = new PedidoModel() { Numero_Cliente = doc };
            //Act
            var result = controller.DeletaPedido(cl);

            //Assert 
            Assert.IsNotNull(result);
        }
    }
}