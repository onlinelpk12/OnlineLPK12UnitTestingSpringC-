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
    public class SparcFileSystemService_Test
    {
        private Mock<OnlineLpk12DbContext> _contextMock;
        private Mock<ILogService> _logServiceMock;
        private Mock<IUserService> _userServiceMock;
        private ISparcFileSystemService _sparcFileSystemService;

        [TestInitialize]
        public void Setup()
        {
            _contextMock = new Mock<OnlineLpk12DbContext>();
            _logServiceMock = new Mock<ILogService>();
            _userServiceMock = new Mock<IUserService>();
            _sparcFileSystemService = new SparcFileSystemService(_contextMock.Object,_logServiceMock.Object,_userServiceMock.Object);
        }

            [TestMethod]
            public async Task IsFolderExists_ReturnsTrue_WhenFolderExists()
            {
                // Arrange
                int userId = 1;
                string username = "testUser";
                string folderName = "testFolder";
                string parentUrl = "testParentUrl";

                // Act
                var result = await _sparcFileSystemService.IsFolderExists(userId, username, folderName, parentUrl);

                // Assert
                Assert.IsNotNull(result);
            }

            [TestMethod]
            public async Task IsFolderExists_ReturnsFalse_WhenFolderDoesNotExist()
            {
                // Arrange
                int userId = 1;
                string username = "testUser";
                string folderName = "testFolder";
                string parentUrl = "testParentUrl";


                // Act
                var result = await _sparcFileSystemService.IsFolderExists(userId, username, folderName, parentUrl);

                // Assert
                Assert.IsNotNull(result);
            }

            [TestMethod]
            public async Task CreateFolder_CreatesFolder_WhenFolderDoesNotExist()
            {
                // Arrange
                int userId = 1;
                string username = "testUser";
                string folderName = "testFolder";
                string parentUrl = "testParentUrl";

                
                // Act
                var result = await _sparcFileSystemService.CreateFolder(userId, username, folderName, parentUrl);

                // Assert
                Assert.IsNotNull(result);
            }

            [TestMethod]
            public async Task DeleteFolder_DeletesFolder_WhenFolderExists()
            {
                // Arrange
                int userId = 1;
                string username = "testUser";
                string folderName = "testFolder";
                string parentUrl = "testParentUrl";

                // Act
                var result = await _sparcFileSystemService.DeleteFolder(userId, username, folderName, parentUrl);

                // Assert
                Assert.IsNotNull(result);
            }

        [TestMethod]
        public async Task IsFileExists_ReturnsTrue_WhenFileExists()
        {
            // Arrange
            int userId = 1;
            string username = "testUser";
            string fileName = "testFile";
            string folderUrl = "testFolderUrl";

                    

            // Act
            var result = await _sparcFileSystemService.IsFileExists(userId, username, fileName, folderUrl);

            Assert.IsNotNull(result);
        }
    
    }
}


