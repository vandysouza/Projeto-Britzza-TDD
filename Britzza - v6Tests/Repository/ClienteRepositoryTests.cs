using Microsoft.VisualStudio.TestTools.UnitTesting;
using Britzza___v6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Britzza___v6.Models;
using MongoDB.Driver;

namespace Britzza___v6.Repository.Tests
{
    [TestClass()]
    public class ClienteRepositoryTests
    {
        [TestMethod()]
        public void BuscaTodosClientes_DeveRetornarListaDeClientesAtivos()
        {
            // Arrange
            var clientesAtivos = new List<ClienteModel>
            {
            new ClienteModel { Id = 1, Enabled = true },
            new ClienteModel { Id = 2, Enabled = true },
            new ClienteModel { Id = 3, Enabled = true }
            };

            var filter = Builders<ClienteModel>.Filter.Eq(c => c.Enabled, true);
            _mockClientesCollection.Setup(c => c.Find(filter).ToList()).Returns(clientesAtivos);

            // Act
            var resultado = _clienteService.BuscaTodosClientes();

            // Assert
            Assert.AreEqual(clientesAtivos, resultado);
        }
    }
}