using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void GetUserByUsernameAndPassword_Found()
        {
            // Arrange
            string username = "Joao";
            string password = "5547";
            var filter = Builders<User>.Filter.Eq(u => u.Username, username) & Builders<User>.Filter.Eq(u => u.Password, password);
            var expectedResult = new User { Username = username, Password = password };

            var mockCursor = new Mock<IAsyncCursor<User>>();
            mockCursor.Setup(c => c.MoveNext(default))
                .Returns(true);
            mockCursor.Setup(c => c.Current)
                 .Returns(() => new List<User> { expectedResult });

            _mockCollection.Setup(c => c.FindSync(It.IsAny<FilterDefinition<User>>(), It.IsAny<FindOptions<User>>(), default))
                .Returns(Mock.Of<IAsyncCursor<User>>());

            // Act
            var user = _userRepository.GetUserByUsernameAndPassword(username, password);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(expectedResult.Username, user.Username);
        }

        [TestMethod]
        public void GetUserByUsernameAndPassword_NotFound()
        {
            // Arrange
            string username = "testuser";
            string password = "testpassword";
            var filter = Builders<User>.Filter.Eq(u => u.Username, username) & Builders<User>.Filter.Eq(u => u.Password, password);

            var mockCursor = new Mock<IAsyncCursor<User>>();
            mockCursor.Setup(c => c.MoveNext(default)).Returns(false);

            _mockCollection.Setup(c => c.FindSync(It.IsAny<FilterDefinition<User>>(), It.IsAny<FindOptions<User>>(), default))
                .Returns(mockCursor.Object);

            // Act
            var user = _userRepository.GetUserByUsernameAndPassword(username, password);

            // Assert
            Assert.IsNull(user);
        }
    }
}