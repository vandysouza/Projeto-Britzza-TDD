using Microsoft.VisualStudio.TestTools.UnitTesting;
using Britzza___v6.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Britzza___v6.Repository;
using Microsoft.AspNetCore.Mvc;
using Britzza___v6.Interfaces;
using Britzza___v6.Models.ViewModels;
using Moq;
using Britzza___v6.Models;

namespace Britzza___v6.Controllers.Tests
{
    [TestClass()]
    public class ClienteControllerTests
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly string connectionString = "mongodb+srv://vandi123:vandiBritzza@cluster0.mjg9q9v.mongodb.net/";
        private readonly string databaseName = "britzza";

        public ClienteControllerTests()
        {
            _clienteRepository = new ClienteRepository(connectionString, databaseName);
        }

        [TestMethod()]
        public void BuscaTodosClientesTest()
        {
            //Arrange
            var controller = new ClienteController(_clienteRepository);

            //Act
            var result = controller.BuscaTodosClientes();
            //Assert 
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void BuscaClientePorDocumentoTest()
        {
            //Arrange
            var clienteRepositoryMock = new Mock<IClienteRepository>();
            var controller = new ClienteController(_clienteRepository);
            string doc = "12345678910";
            ResultClienteModel cl = new ResultClienteModel() { BuscaDocumento = doc };
            //Act
            var result = controller.BuscaClientePorDocumento(cl);
            
            //Assert 
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public void CriaClienteTest()
        { 
            //Arrange
            var clienteRepositoryMock = new Mock<IClienteRepository>();
            var controller = new ClienteController(clienteRepositoryMock.Object);
            var model = new ClienteModel
            {
                Endereco = "Rua America, 21 - SP",
                Nome = "Joao Pedro",
                Telefone = "11965654829",
                NumeroDocumento = "12345678910",
                Enabled = true,
            };

            clienteRepositoryMock.Setup(u => u.CriaCliente(It.IsAny<ClienteModel>())); // Configuração do Mock
            // Act
            var result = controller.CriaCliente(model) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.Fail();
        }

        [TestMethod()]
        public void AlteraClienteTest()
        {
            //Arrange
            var clienteRepositoryMock = new Mock<IClienteRepository>();
            var controller = new ClienteController(clienteRepositoryMock.Object);
            var model = new ClienteModel
            {
                Endereco = "Rua America, 1234 - SP",
                Nome = "Rogerio Pedro",
                Telefone = "1196565429",
                NumeroDocumento = "12345678910",
                Enabled = true,
            };

            clienteRepositoryMock.Setup(u => u.AlteraCliente(It.IsAny<ClienteModel>())); // Configuração do Mock
            // Act
            var result = controller.AlteraCliente(model) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DesabilitaClienteTest()
        {
            var clienteRepositoryMock = new Mock<IClienteRepository>();
            var controller = new ClienteController(_clienteRepository);
            string doc = "12345678910";

            ClienteModel cl = new ClienteModel() { NumeroDocumento = doc };
            //Act
            var result = controller.DesabilitaCliente(cl);

            //Assert 
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeletaClienteTest()
        {
            var clienteRepositoryMock = new Mock<IClienteRepository>();
            var controller = new ClienteController(_clienteRepository);
            string doc = "12345678910";

            ClienteModel cl = new ClienteModel() { NumeroDocumento = doc };
            //Act
            var result = controller.DeletaCliente(cl);

            //Assert 
            Assert.IsNotNull(result);
        }
    }
}