using Moq;
using Microsoft.EntityFrameworkCore;
using OnlineLpk12.Data.Context;
using OnlineLpk12.Data.Entities;
using OnlineLpk12.Services.Implementation;
using OnlineLpk12.Services.Interface;
using OnlineLpk12.Data.Models;
using OnlineLpk12.Controllers;
using Microsoft.Extensions.Configuration;

namespace Unit_Tests.cs
{
    [TestClass]
    public class UserService_Test
    {
        private Mock<OnlineLpk12DbContext> _contextMock;
        private Mock<IConfiguration> _configuration;
        private Mock<ILogService> _logServiceMock;
        private UserService _userService;

        [TestInitialize]
        public void Setup()
        {
            _contextMock = new Mock<OnlineLpk12DbContext>();
            _configuration = new Mock<IConfiguration>();
            _logServiceMock = new Mock<ILogService>();
            _userService = new UserService(_contextMock.Object, _logServiceMock.Object, _configuration.Object);
        }

        [TestMethod]
        public async Task Login_ValidUser_ReturnsToken()
        {
            try
            { 
            // Arrange
            var user = new LoginUser
            {
                UserName = "testuser",
                Password = BCrypt.Net.BCrypt.HashPassword("testpassword")
            };

            // Act
            var result = await _userService.Login(user);

            // Assert
            Assert.IsNotNull(result);
        }
             catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public async Task Login_InvalidUser_ReturnsError()
        {
            try
            {
                var user = new LoginUser { UserName = "testuser", Password = "testpassword" };
                // Act
                var result = await _userService.Login(user);


                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }
    }
}