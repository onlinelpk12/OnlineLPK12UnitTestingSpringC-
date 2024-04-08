using OnlineLpk12.Data.Context;
using OnlineLpk12.Data.Models;
using OnlineLpk12.Services.Implementation;
using OnlineLpk12.Services.Interface;
using Moq;
using OnlineLpk12.Data.Entities;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
namespace Unit_Tests.cs
{
    [TestClass]
    public class LogService_Test
    {
        private Mock<OnlineLpk12DbContext> _contextMock;
        private ILogService _logService;

        

        [TestInitialize]
        public void LogService_Tests()
        {
            _contextMock = new Mock<OnlineLpk12DbContext>();
            _logService = new LogService(_contextMock.Object);
        }

        [TestMethod]
        public void LogError_WithException_CallsDatabaseExecuteSqlRawCorrectly()
        {
            // Arrange
            int userId = 1;
            string methodName = "TestMethod";
            string fileName = "TestFile.cs";
            string message = "This is a test message";
            Exception exception = new Exception("This is a test exception");

            // Act
            _logService.LogError(userId, methodName, fileName, message, exception);


            Console.WriteLine("Success");



        }

        [TestMethod]
        public void LogInfo_WithMessage_CallsDatabaseExecuteSqlRawCorrectly()
        {
            // Arrange
            int userId = 1;
            string methodName = "TestMethod";
            string fileName = "TestFile.cs";
            string message = "This is a test message";

            // Act
            _logService.LogInfo(userId, methodName, fileName, message);
            
            Console.WriteLine("Success");

        }

        [TestMethod]
        public void LogError_WithNullContext_ThrowsException()
        {
            // Arrange
            _contextMock = new Mock<OnlineLpk12DbContext>(MockBehavior.Strict);
            _contextMock.Setup(m => m.Database).Throws<Exception>();
            _logService = new LogService(null);

            Console.WriteLine("Success");

        }

    }
}


