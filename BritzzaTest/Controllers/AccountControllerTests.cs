using Britzzav4.Controllers;
using Britzzav4.Interfaces;
using Britzzav4.Models;
using Britzzav4.Models.ViewModels;
using Britzzav4.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace BritzzaTest.Controllers
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

        [TestMethod]
        public void Login_ReturnsView()
        {
            // Arrange
            var controller = new AccountController(_userRepository);

            // Act
            var result = controller.Login();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Login_SuccessAsync()
        {
            // Arrange
            var controller = new AccountController(_userRepository);
            var model = new LoginViewModel
            {
                Username = "Joao",
                Password = "5547"
            };

            // Act
            var result = controller.Login(model) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }

        [TestMethod]
        public void Login_Error()
        {
            // Arrange
            var controller = new AccountController(_userRepository);
            var model = new LoginViewModel
            {
                Username = "Joaquim",
                Password = "5547"
            };

            // Act
            var result = controller.Login(model) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
            Assert.IsTrue(result.ViewData.ModelState.ContainsKey(""));
            Assert.AreEqual("Invalid username or password", result.ViewData.ModelState[""].Errors[0].ErrorMessage);
        }

        [TestMethod]
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
