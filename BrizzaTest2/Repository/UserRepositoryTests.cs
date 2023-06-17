using Microsoft.VisualStudio.TestTools.UnitTesting;
using Britzza___v6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Britzza___v6.Models;
using MongoDB.Driver;
using Moq;
using Britzza___v6.Controllers;
using Britzza___v6.Interfaces;
using Britzza___v6.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Britzza___v6.Repository.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        private readonly Mock<IMongoCollection<User>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly UserRepository _userRepository;
        private readonly string connectionString = "mongodb+srv://vandi123:vandiBritzza@cluster0.mjg9q9v.mongodb.net/";
        private readonly string databaseName = "britzza";

        public UserRepositoryTests()
        {
            _mockCollection = new Mock<IMongoCollection<User>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockDatabase.Setup(db => db.GetCollection<User>("users", null))
            .Returns(_mockCollection.Object);

            _userRepository = new UserRepository(connectionString, databaseName);
        }


        [TestMethod]
        public void CreateUserTest_Success()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var controller = new AccountController(userRepositoryMock.Object);
            var user = new User
            {
                Username = "testandoo",
                Email = "testando@example.com",
                Password = "testandopassword",
                Function = "Operador"
            };

            // Act
            userRepositoryMock.Setup(u => u.CreateUser(user));
            var result = controller.Register(new RegisterViewModel
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Function = user.Function
            }) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Login", result.ActionName);
        }
    }
}