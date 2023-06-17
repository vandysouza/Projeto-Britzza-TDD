﻿using Microsoft.AspNetCore.Mvc;
using Britzza___v6.Repository;
using Britzza___v6.Interfaces;
using Britzza___v6.Models.ViewModels;
using Moq;
using Britzza___v6.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Britzza___v6.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        private readonly UserRepository _userRepository;
        private readonly string connectionString = "mongodb+srv://vandi123:vandiBritzza@cluster0.mjg9q9v.mongodb.net/";
        private readonly string databaseName = "britzza";
        public AccountControllerTests()
        {
            _userRepository = new UserRepository(connectionString, databaseName);
        }

        [TestMethod()]
        public void Register_ReturnsView()
        {
            // Arrange
            var controller = new AccountController(_userRepository);

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        [TestMethod()]
        public void Register_Success()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var controller = new AccountController(userRepositoryMock.Object);
            var model = new RegisterViewModel
            {
                Username = "validuser",
                Email = "validemail@example.com",
                Password = "validpassword"
            };

            userRepositoryMock.Setup(u => u.CreateUser(It.IsAny<User>())); // Configuração do Mock

            // Act
            var result = controller.Register(model) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Login", result.ActionName);
        }
    }
}